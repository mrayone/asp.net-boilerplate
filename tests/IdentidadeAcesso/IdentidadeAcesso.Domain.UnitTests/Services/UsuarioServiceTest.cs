using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Domain.Sevices;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.Services
{
    public class UsuarioServiceTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUsuarioRepository> _userRepo;
        private readonly Usuario _usuario;
        private readonly UsuarioService _service;

        public UsuarioServiceTest()
        {
            _mediator = new Mock<IMediator>();
            _userRepo = new Mock<IUsuarioRepository>();
            _usuario = UsuarioBuilder.ObterUsuarioCompletoValido();
            _service = new UsuarioService(_userRepo.Object, _mediator.Object);
            _userRepo.Setup(r => r.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(_usuario);
        }

        [Fact(DisplayName = "Deve desativar o usuário e retornar o mesmo.")]
        [Trait("Services", "Usuario - Desativar")]
        public async Task Deve_Desativar_O_Usuario_e_Retornar_O_Mesmo()
        {
            //arrange
            var userId = Guid.NewGuid();

            //act
            var result = await _service.DesativarUsuarioAsync(userId);

            //assert

            result.Status.Valor.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar null caso não encontrar usuário pelo id.")]
        [Trait("Services", "Usuario - Desativar")]
        public async Task Deve_retornar_null_caso_nao_encontrar_usuario()
        {
            //arrange
            _userRepo.Setup(r => r.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync((Usuario)null);
            //act
            var result = await _service.DesativarUsuarioAsync(Guid.Empty);

            //assert

            result.Should().BeNull();
            _mediator.Verify(n => n.Publish(It.IsAny<DomainNotification>(), 
                new System.Threading.CancellationToken()));
        }
    }
}
