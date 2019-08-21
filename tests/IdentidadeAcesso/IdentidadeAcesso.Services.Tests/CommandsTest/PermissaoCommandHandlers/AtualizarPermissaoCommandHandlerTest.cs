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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PermissaoCommandHandlers
{
    public class AtualizarPermissaoCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPermissaoRepository> _permissaoRepository;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly DomainNotificationHandler _notifications;
        private readonly AtualizarPermissaoCommandHandler _handler;
        public AtualizarPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _permissaoRepository = new Mock<IPermissaoRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new DomainNotificationHandler();
            _handler = new AtualizarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications, _permissaoRepository.Object);
            _permissaoRepository.Setup(p => p.ObterPorIdAsync(It.IsAny<Guid>())).ReturnsAsync(PermissaoBuilder.CriarPermissaoFake());
        }

        [Fact(DisplayName = "O handle deve retornar false e disparar notificação se permissão com mesmo valor já existir.")]
        [Trait("Handler - Permissão", "AtualizarPermissão")]
        public async Task Handle_deve_retornar_false_e_disparar_notificacao_se_permissao_com_mesmo_valor_ja_existir()
        {
            //arrange
            var commandFake = new AtualizarPermissaoCommand(Guid.NewGuid(), "Usuário", "Cadastrar");
            var listMock = new List<Permissao>()
            {
                PermissaoBuilder.CriarPermissaoFake()
            };
            _permissaoRepository.Setup(r => r.Buscar(It.IsAny<Expression<Func<Permissao, bool>>>())).ReturnsAsync(listMock);
            
            //act
            var result = await _handler.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "O Handle deve atualizar com sucesso a permissão.")]
        [Trait("Handler - Permissão", "AtualizarPermissão")]
        public async Task Handle_deve_cadastrar_com_sucesso()
        {
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            var commandFake = new AtualizarPermissaoCommand(Guid.NewGuid(),"Usuário", "Editar");
            //act
            var result = await _handler.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Success.Should().BeTrue();

            _mediator.Verify(m => m.Publish(It.IsAny<PermissaoAtualizadaEvent>(), default), Times.Once());
        }
    }
}
