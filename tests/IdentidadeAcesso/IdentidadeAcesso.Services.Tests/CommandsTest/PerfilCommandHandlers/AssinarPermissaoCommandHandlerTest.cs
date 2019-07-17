using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers.Builder;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers
{
    public class AssinarPermissaoCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IPerfilService> _service;
        private readonly AssinarPermissaoCommandHandler _handler;
        private readonly List<AssinaturaDTO> _list;

        public AssinarPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new DomainNotificationHandler();

            _service = new Mock<IPerfilService>();
            _handler = new AssinarPermissaoCommandHandler(_mediator.Object, _uow.Object, 
                _notifications, _service.Object, _perfilRepositoryMock.Object);

            _perfilRepositoryMock.Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(TestBuilder.PerfilFalso());

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);

            _list = new List<AssinaturaDTO>()
            {
                new AssinaturaDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                },
                new AssinaturaDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                }
            };
        }

        [Fact(DisplayName = "Deve assinar permissão e retornar true .")]
        [Trait("Handler - Perfil", "AssinarPermissaoCommand")]
        public async Task Deve_AssinarPermissao_e_Retornar_True()
        {
            //arrange
            var perfil = TestBuilder.PerfilFalso();
            _service.Setup(s => s.AssinarPermissaoAsync(It.IsAny<Perfil>(), It.IsAny<Guid>()))
                .ReturnsAsync(perfil);
            var command = new AssinarPermissaoCommand(perfil.Id, _list);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Success.Should().BeTrue();
            _service.Verify(s => s.AssinarPermissaoAsync(perfil, It.IsAny<Guid>()), Times.Once);
            _uow.Verify(u => u.Commit(), Times.Once);
        }
    }
}
