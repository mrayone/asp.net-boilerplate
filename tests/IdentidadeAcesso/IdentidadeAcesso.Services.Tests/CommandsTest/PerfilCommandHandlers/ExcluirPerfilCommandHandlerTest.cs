
using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
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
        private readonly Mock<IPerfilService> _service;

        public ExcluirPerfilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
            _service = new Mock<IPerfilService>();
        }

        [Fact(DisplayName = "O Handle deve verificar se comando invalido e retornar false.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_verificar_se_comando_invalido_e_retornar_false()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.Empty);
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object, _service.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
        }

        [Fact(DisplayName = "O handle deve retornar falso se o perfil não existir.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir()
        {
            //arrange

            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object, _service.Object);

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
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object, _service.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O Handle deve retornar false se perfil em uso e disparar notificacao.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_false_se_perfil_em_uso_e_disparar_notificacao()
        {
            //arrange

            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(TestBuilder.PerfilFalso());

            _service.Setup(s => s.DeletarPerfilAsync(It.IsAny<Guid>())).ReturnsAsync(false);
            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object, _service.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(false);
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O Handle deve retornar true se excluir o perfil com sucesso.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_verdadeiro_se_excluir_o_perfil_com_sucesso()
        {
            //arrange

            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            _service.Setup(s => s.DeletarPerfilAsync(It.IsAny<Guid>())).ReturnsAsync(true);
            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(TestBuilder.PerfilFalso());

            var handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _perfilRepositoryMock.Object, _service.Object);

            //act
            var result = await handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Should().Be(true);
            _mediator.Verify(m => m.Publish(It.IsAny<PerfilDeletadoEvent>(), default), Times.Once());
        }
    }
}
