using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.PermissaoCommandHandlers.Builder;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PermissaoCommandHandlers
{
    public class ExcluirPermissaoCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPermissaoRepository> _permissaoRepository;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IPermissaoService> _service;
        private readonly ExcluirPermissaoCommandHandler _handler;
        public ExcluirPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _permissaoRepository = new Mock<IPermissaoRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new DomainNotificationHandler();
            _service = new Mock<IPermissaoService>();
            _handler = new ExcluirPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications, _permissaoRepository.Object , _service.Object);
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            _service.Setup(s => s.DeletarPermissaoAsync(It.IsAny<Permissao>())).ReturnsAsync(true);
            _permissaoRepository.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(PermissaoBuilder.CriarPermissaoFake());

        }

        [Trait("Handler - Permissão", "ExcluirPermissão")]
        [Fact(DisplayName = "O handle deve excluir a permissão e não conter erros.")]
        public async Task Handle_Deve_Excluir_Permissao_e_NaoConter_Erros()
        {
            //arrange
            var command = new ExcluirPermissaoCommand(Guid.NewGuid());

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeTrue();
        }

        [Trait("Handler - Permissão", "ExcluirPermissão")]
        [Fact(DisplayName = "O handle deve notificar se permissão não encontrada.")]
        public async Task Handle_Deve_Notificar_Se_Permissao_Nao_Encontrada()
        {
            //arrange
            var command = new ExcluirPermissaoCommand(Guid.NewGuid());
            _permissaoRepository.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync((Permissao) null);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeFalse();
        }

        [Trait("Handler - Permissão", "ExcluirPermissão")]
        [Fact(DisplayName = "O handle deve retornar false se não conseguir deletar permissão.")]
        public async Task Handle_Deve_Retornar_False_Se_Nao_Conseguir_Deletar()
        {
            //arrange
            var command = new ExcluirPermissaoCommand(Guid.NewGuid());
            _service.Setup(s => s.DeletarPermissaoAsync(It.IsAny<Permissao>())).ReturnsAsync(false);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeFalse();
        }

        [Trait("Handler - Permissão", "ExcluirPermissão")]
        [Fact(DisplayName = "O handle deve realizar a operação com sucesso.")]
        public async Task Handle_Deve_Realiar_a_Operacao_Com_Sucesso()
        {
            //arrange
            var command = new ExcluirPermissaoCommand(Guid.NewGuid());

            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Success.Should().BeTrue();
            _mediator.Verify(p => p.Publish(It.IsAny<PermissaoExcluidaEvent>(), new System.Threading.CancellationToken()), Times.Once());
        }

    }
}
