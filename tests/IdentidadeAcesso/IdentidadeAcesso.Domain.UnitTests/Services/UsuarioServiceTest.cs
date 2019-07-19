using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
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
        private readonly Mock<IPerfilRepository> _perfilRepo;
        private readonly Usuario _usuario;
        private readonly UsuarioService _service;

        public UsuarioServiceTest()
        {
            _mediator = new Mock<IMediator>();
            _userRepo = new Mock<IUsuarioRepository>();
            _perfilRepo = new Mock<IPerfilRepository>();
            _usuario = UsuarioBuilder.ObterUsuarioCompletoValido();
            _service = new UsuarioService(_userRepo.Object, _perfilRepo.Object, _mediator.Object);
        }

        [Fact(DisplayName = "Deve desativar o usuário e retornar o mesmo.")]
        [Trait("Services", "Usuario - Desativar")]
        public async Task Deve_Desativar_O_Usuario_e_Retornar_O_Mesmo()
        {
            //arrange
            _userRepo.Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
                    .ReturnsAsync(_usuario);
            var userId = Guid.NewGuid();

            //act
            var result = await _service.DesativarUsuarioAsync(userId);

            //assert

            result.Status.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar null caso não encontrar usuário pelo id.")]
        [Trait("Services", "Usuario - Desativar")]
        public async Task Deve_retornar_null_caso_nao_encontrar_usuario()
        {
            //act
            var result = await _service.DesativarUsuarioAsync(Guid.Empty);

            //assert

            result.Should().BeNull();
            _mediator.Verify(n => n.Publish(It.IsAny<DomainNotification>(), 
                new System.Threading.CancellationToken()));
        }

        [Fact(DisplayName = "Deve retoranr false se não vincular o perfil ao Usuário.")]
        [Trait("Services", "Usuario - Desativar")]
        public async Task Deve_Retornar_False_Se_Nao_Vincular_Perfil_Ao_Usuario()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();

            //act
            var result = await _service.VincularAoPerfilAsync(Guid.Empty, usuario);

            //assert

            result.Should().BeFalse();
            _mediator.Verify(n => n.Publish(It.IsAny<DomainNotification>(),
                new System.Threading.CancellationToken()));
        }
    }
}
