using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
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
    public class CancelarPermissoesPefilCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notifications;
        private readonly Mock<IPerfilService> _service;
        private readonly CancelarPermissaoCommandHandler _handler;

        public CancelarPermissoesPefilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<IDomainNotificationHandler<DomainNotification>>();
            _service = new Mock<IPerfilService>();

            _handler = new CancelarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object,
                _service.Object, _perfilRepositoryMock.Object);
        }

        [Fact(DisplayName = "O Handle deve retornar falso se o perfil não existir.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir()
        {
            //arrange
            var perfilId = Guid.NewGuid();
            var permissao =
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                    Status = true
                };

            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>()));

            var command = new CancelarPermissaoCommand(perfilId, permissao.PermissaoId);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await _handler.Handle(command, cancelToken);

            //assert
            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "O handle deve retornar verdadeiro se cancelar com sucesso as permissões.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_verdadeiro_se_cancelar_com_sucesso_as_permissoes()
        {
            //arrange
            var perfilId = Guid.NewGuid();
            var permissao1 = Guid.NewGuid();
            
            var perfil = TestBuilder.PerfilFalso();
            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(perfil);
            _service.Setup(s => s.CancelarPermissaoAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .ReturnsAsync(perfil);

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            var command = new CancelarPermissaoCommand(perfilId, permissao1);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await _handler.Handle(command, cancelToken);

            //assert
            result.Success.Should().BeTrue();
            _mediator.Verify(m => m.Publish(It.IsAny<AssinaturaPermissaoCanceladaEvent>(), default), Times.Once());
        }
    }
}
