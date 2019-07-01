using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using Knowledge.IO.Infra.Data.UoW;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task  Deve_Retornar_True_Se_Usuario_Registrado()
        {
            //arrange
            var command = CommandBuilder.ObterCommandFake();
            //act

            //assert
        }

    }
}
