using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers.Builder;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers
{
    public class ExcluirUsuarioCommandHandlerTest
    {
        private readonly ExcluirUsuarioCommandHandler _handler;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<IUsuarioRepository> _repository;
        private readonly Mock<IUsuarioService> _service;
        private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notifications;
        
        public ExcluirUsuarioCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _repository = new Mock<IUsuarioRepository>();
            _uow = new Mock<IUnitOfWork>();
            _service = new Mock<IUsuarioService>();
            _notifications = new Mock<IDomainNotificationHandler<DomainNotification>>();
            _handler = new ExcluirUsuarioCommandHandler(_mediator.Object, _uow.Object, _repository.Object, _service.Object, _notifications.Object);

            _uow.Setup(uow => uow.Commit()).ReturnsAsync(CommandResponse.Ok);

        }

        [Fact(DisplayName = "Deve retornar false se comando inválido.")]
        [Trait("Handler","ExcluirUsuario")]
        public async Task Deve_Retornar_False_Se_Comando_Invalido()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeExcluirInvalido();

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            
            //assert
            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar false se usuário não existir.")]
        [Trait("Handler", "ExcluirUsuario")]
        public async Task Deve_Retornar_False_Se_Usuario_Nao_Existe()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeExcluir();

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar true e marcar usuario como deletado.")]
        [Trait("Handler", "ExcluirUsuario")]
        public async Task Deve_Retornar_True_e_Marcar_Usuario_Como_Deletado()
        {
            //arrange
            var command = UsuarioBuilder.ObterCommandFakeExcluir();
            var usuarioFake = UsuarioBuilder.UsuarioFake();
            _repository.Setup(u => u.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(usuarioFake);
            _service.Setup(u => u.DeletarUsuarioAsync(It.IsAny<Guid>())).ReturnsAsync(() => 
            {
                usuarioFake.Deletar();
                return usuarioFake;
            });
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeTrue();
            usuarioFake.DeletadoEm.HasValue.Should().BeTrue();
            _mediator.Verify(p => p.Publish(It.IsAny<UsuarioDeletadoEvent>(), 
                new System.Threading.CancellationToken()), Times.Once());
        }
    }
}
