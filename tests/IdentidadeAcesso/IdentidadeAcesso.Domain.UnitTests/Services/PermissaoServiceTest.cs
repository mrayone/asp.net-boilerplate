using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.Sevices;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.Services
{
    public class PermissaoServiceTest
    {
        private readonly PermissaoService _service;
        private readonly Mock<IPermissaoRepository> _repositoryMock;
        public PermissaoServiceTest()
        {
            _repositoryMock = new Mock<IPermissaoRepository>();
            _service = new PermissaoService(_repositoryMock.Object);
            _repositoryMock.Setup(e => e.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(PermissaoBuilder.ObterPermissaoFake());
        }

        [Trait("Services","Permissao")]
        [Fact(DisplayName = "Deve deletar a permissão e retornar true.")]
        public async Task Deve_Deletar_a_Permissao_e_Retornar_True()
        {
            //arrange
            var permissao = await _repositoryMock.Object.ObterPorId(Guid.NewGuid());

            //act
            var result = await _service.DeletarPermissao(permissao);

            //assert
            result.Should().BeTrue();
            permissao.DeletadoEm.HasValue.Should().BeTrue();
        }

        [Trait("Services", "Permissao")]
        [Fact(DisplayName = "Deve retornar false se permissão em uso e disparar notificação de domínio.")]
        public async Task Deve_Retornar_False_Se_Permissao_Em_Uso_e_Disparar_Notificacao_de_Dominio()
        {

        }
    }
}
