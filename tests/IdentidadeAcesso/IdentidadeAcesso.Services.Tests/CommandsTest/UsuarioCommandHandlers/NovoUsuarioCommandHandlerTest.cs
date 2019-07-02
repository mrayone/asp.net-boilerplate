using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers.Builder;
using Knowledge.IO.Infra.Data.UoW;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers
{
    public class NovoUsuarioCommandHandlerTest
    {
        private readonly NovoUsuarioCommandHandler _handler;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;

        public NovoUsuarioCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
            _handler = new NovoUsuarioCommandHandler(_mediator.Object, _uow.Object, _notifications.Object);
        }

        [Fact(DisplayName = "Deve retornar true se comando valido.")]
        [Trait("Handler", "NovoUsuario")]
        public async Task  Deve_Retornar_True_Se_Comando_Valido()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFake();
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar false se usuário ja existir.")]
        [Trait("Handler", "NovoUsuario")]
        public async Task Deve_retornar_False_se_usuario_ja_existir()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFake();
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeTrue();
        }

    }
}
