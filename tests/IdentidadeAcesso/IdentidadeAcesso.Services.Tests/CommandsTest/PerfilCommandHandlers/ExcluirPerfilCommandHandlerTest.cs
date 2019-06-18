
using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers.Builders;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers
{
    public class ExcluirPerfilCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;

        public ExcluirPerfilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
        }

        [Fact(DisplayName = "O Handle deve verificar se comando invalido e retornar false.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_verificar_se_comando_invalido_e_retornar_false()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.Empty);
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
        }

        [Fact(DisplayName = "O deve retornar falso se o perfil não existir.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir()
        {
            //arrange

            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
        }

        [Fact(DisplayName = "O deve retornar falso se o perfil não existir e disparar notificação de domínio.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir_e_disparar_notificacao_de_dominio()
        {
            //arrange

            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O Handle deve verificar se o perfil não esta em uso.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_verificar_se_o_perfil_nao_esta_em_uso()
        {
            //arrange

            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }
    }
}
