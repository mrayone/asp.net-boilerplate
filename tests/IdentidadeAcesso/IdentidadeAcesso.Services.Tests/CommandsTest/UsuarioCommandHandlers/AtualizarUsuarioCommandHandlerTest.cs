using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers.Builder;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers
{
    public class AtualizarUsuarioCommandHandlerTest
    {
        private readonly AtualizarUsuarioCommandHandler _handler;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<IUsuarioRepository> _repository;
        private readonly Mock<IUsuarioService> _service;
        private readonly Mock<IDomainNotificationHandler<INotification>> _notifications;

        public AtualizarUsuarioCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _repository = new Mock<IUsuarioRepository>();
            _uow = new Mock<IUnitOfWork>();
            _service = new Mock<IUsuarioService>();
            _notifications = new Mock<IDomainNotificationHandler<INotification>>();
            _handler = new AtualizarUsuarioCommandHandler(_mediator.Object, _uow.Object, _repository.Object, _service.Object, _notifications.Object);
            _uow.Setup(uow => uow.Commit()).ReturnsAsync(CommandResponse.Ok);
            _service.Setup(s => s.VerificarPerfilExistenteAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            _repository.Setup(u => u.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(UsuarioBuilder.UsuarioFake());
        }

        [Fact(DisplayName = "Deve retornar true se comando valido.")]
        [Trait("Handler", "AtualizarUsuario")]
        public async Task Deve_Retornar_True_Se_Comando_Valido()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeAtualizar();
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar false se usuário ja existir.")]
        [Trait("Handler", "AtualizarUsuario")]
        public async Task Deve_Retornar_False_Se_Usuario_Ja_Existir()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeAtualizar();
            _repository.Setup(r => r.Buscar(It.IsAny<Expression<Func<Usuario, bool>>>()))
                .ReturnsAsync(new List<Usuario>()
                {
                    UsuarioBuilder.UsuarioFake()
                });
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            _mediator.Verify(p => p.Publish(It.IsAny<DomainNotification>(),
                new System.Threading.CancellationToken()), Times.Once());
        }

        [Fact(DisplayName = "Deve retornar false se usuário houver erros de domínio.")]
        [Trait("Handler", "AtualizarUsuario")]
        public async Task Deve_Retornar_False_Se_Houver_Erros_De_Domain()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeAtualizarErroDeDomain();
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            _mediator.Verify(p => p.Publish(It.IsAny<DomainNotification>(),
                new System.Threading.CancellationToken()), Times.Between(1, 2, Range.Inclusive));
        }

        [Fact(DisplayName = "Deve retornar false e notificar se perfil atribuido não existir.")]
        [Trait("Handler", "AtualizarUsuario")]
        public async Task Deve_Retornar_False_E_Notificar_Se_Perfil_Atribuido_Nao_Exisitir()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeAtualizar();
            _service.Setup(s => s.VerificarPerfilExistenteAsync(It.IsAny<Guid>()))
                .ReturnsAsync(false);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            _mediator.Verify(p => p.Publish(It.IsAny<DomainNotification>(),
                new System.Threading.CancellationToken()), Times.Once());
        }

        [Fact(DisplayName = "Deve persistir Usuario e Disparar Evento.")]
        [Trait("Handler", "AtualizarUsuario")]
        public async Task Deve_Persistir_Usuario_E_Disparar_Evento()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeAtualizar();
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Should().BeTrue();
            _mediator.Verify(p => p.Publish(It.IsAny<UsuarioAtualizadoEvent>(),
                new System.Threading.CancellationToken()), Times.Once());
        }
    }
}
