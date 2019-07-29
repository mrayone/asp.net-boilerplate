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
    public class AtribuirPermissaoCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IPerfilService> _service;
        private readonly AtribuirPermissaoCommandHandler _handler;
        private readonly List<AtribuicaoDTO> _list;

        public AtribuirPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new DomainNotificationHandler();

            _service = new Mock<IPerfilService>();
            _handler = new AtribuirPermissaoCommandHandler(_mediator.Object, _uow.Object, 
                _notifications, _service.Object, _perfilRepositoryMock.Object);

            _perfilRepositoryMock.Setup(r => r.ObterComPermissoesAsync(It.IsAny<Guid>()))
                .ReturnsAsync(TestBuilder.PerfilFalso());

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);

            _list = new List<AtribuicaoDTO>()
            {
                new AtribuicaoDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                },
                new AtribuicaoDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                }
            };
        }

        [Fact(DisplayName = "Deve assinar permissão e retornar true .")]
        [Trait("Handler - Perfil", "AtribuirPermissaoCommand")]
        public async Task Deve_AssinarPermissao_e_Retornar_True()
        {
            //arrange
            var perfil = TestBuilder.PerfilFalso();
            _service.Setup(s => s.AtribuirPermissaoAsync(It.IsAny<Perfil>(), It.IsAny<Guid>()))
                .ReturnsAsync(perfil);
            var command = new AtribuirPermissaoCommand(perfil.Id, _list);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Success.Should().BeTrue();
            _service.Verify(s => s.AtribuirPermissaoAsync(perfil, It.IsAny<Guid>()), Times.Once);
            _uow.Verify(u => u.Commit(), Times.Once);
        }
    }
}
