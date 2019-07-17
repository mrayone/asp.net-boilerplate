
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
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IPerfilService> _service;
        private readonly ExcluirPerfilCommandHandler _handler;

        public ExcluirPerfilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new DomainNotificationHandler();
            _service = new Mock<IPerfilService>();
            _handler = new ExcluirPerfilCommandHandler(_mediator.Object, _uow.Object, 
                _notifications, _perfilRepositoryMock.Object, _service.Object);
        }

        [Fact(DisplayName = "O Handle deve verificar se comando invalido e retornar false.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_verificar_se_comando_invalido_e_retornar_false()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.Empty);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "O handle deve retornar falso se o perfil não existir.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.NewGuid());

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert

            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "O deve retornar falso se o perfil não existir e disparar notificação de domínio.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir_e_disparar_notificacao_de_dominio()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.NewGuid());

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeFalse();
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O Handle deve retornar false se perfil em uso e disparar notificacao.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_false_se_perfil_em_uso_e_disparar_notificacao()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            _perfilRepositoryMock.Setup(p => p.ObterPorIdAsync(It.IsAny<Guid>())).ReturnsAsync(TestBuilder.PerfilFalso());
            _service.Setup(s => s.DeletarPerfilAsync(It.IsAny<Perfil>())).ReturnsAsync(false);

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeFalse();
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O Handle deve retornar true se excluir o perfil com sucesso.")]
        [Trait("Handler - Perfil", "ExcluirPerfil")]
        public async Task Handle_deve_retornar_verdadeiro_se_excluir_o_perfil_com_sucesso()
        {
            //arrange
            var command = new ExcluirPerfilCommand(Guid.NewGuid());
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            _service.Setup(s => s.DeletarPerfilAsync(It.IsAny<Perfil>())).ReturnsAsync(true);
            _perfilRepositoryMock.Setup(p => p.ObterPorIdAsync(It.IsAny<Guid>())).ReturnsAsync(TestBuilder.PerfilFalso());

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
           
            //assert
            result.Success.Should().BeTrue();
            _mediator.Verify(m => m.Publish(It.IsAny<PerfilDeletadoEvent>(), default), Times.Once());
        }
    }
}
