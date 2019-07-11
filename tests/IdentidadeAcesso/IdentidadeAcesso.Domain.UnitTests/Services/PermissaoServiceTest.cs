using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Domain.Sevices;
using IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.Services
{
    public class PermissaoServiceTest
    {
        private readonly PermissaoService _service;
        private readonly Mock<IPermissaoRepository> _repositoryMock;
        private readonly Mock<IPerfilRepository> _perfilRepoMock;
        private readonly Mock<IMediator> _mediator;
        private readonly IList<Perfil> _listMock;
        public PermissaoServiceTest()
        {
            _repositoryMock = new Mock<IPermissaoRepository>();
            _perfilRepoMock = new Mock<IPerfilRepository>();
            _mediator = new Mock<IMediator>();
            _service = new PermissaoService(_repositoryMock.Object, _mediator.Object, _perfilRepoMock.Object);

            _repositoryMock.Setup(e => e.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(PermissaoBuilder.ObterPermissaoFake());
            _listMock = new List<Perfil>()
            {
                PerfilBuilder.ObterPerfil()
            };
        }

        [Trait("Services","Permissao")]
        [Fact(DisplayName = "Deve deletar a permissão e retornar true.")]
        public async Task Deve_Deletar_a_Permissao_e_Retornar_True()
        {
            //arrange
            var permissao = await _repositoryMock.Object.ObterPorId(Guid.NewGuid());

            //act
            var result = await _service.DeletarPermissaoAsync(permissao);

            //assert
            result.Should().BeTrue();
            permissao.DeletadoEm.HasValue.Should().BeTrue();
        }

        [Trait("Services", "Permissao")]
        [Fact(DisplayName = "Deve retornar false se permissão em uso e disparar notificação de domínio.")]
        public async Task Deve_Retornar_False_Se_Permissao_Em_Uso_e_Disparar_Notificacao_de_Dominio()
        {
            //arrange
            _perfilRepoMock.Setup(e => e.Buscar(It.IsAny<Expression<Func<Perfil, bool>>>()))
            .ReturnsAsync(_listMock);
            var permissao = await _repositoryMock.Object.ObterPorId(Guid.NewGuid());

            //act
            var result = await _service.DeletarPermissaoAsync(permissao);

            //assert
            result.Should().BeFalse();
            permissao.DeletadoEm.HasValue.Should().BeFalse();
            _mediator.Verify(p => p.Publish(It.IsAny<DomainNotification>(), 
                new System.Threading.CancellationToken()), Times.Once());
        }
    }
}
