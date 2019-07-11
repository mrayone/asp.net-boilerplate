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
        private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notifications;

        public AtualizarPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _permissaoRepository = new Mock<IPermissaoRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<IDomainNotificationHandler<DomainNotification>>();

            _permissaoRepository.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(PermissaoBuilder.CriarPermissaoFake());
        }

        [Fact(DisplayName = "O handle deve retornar false para comando inválido.")]
        [Trait("Handler - Permissão", "AtualizarPermissão")]
        public async Task Handle_deve_retornar_false_para_comando_invalido()
        {
            //arrange
            var commandFake = new AtualizarPermissaoCommand(Guid.Empty,"", "C");
            var handle = new AtualizarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            commandFake.ValidationResult.Errors.Should().NotBeEmpty();
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
            var handle = new AtualizarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            _mediator.Verify(p=> p.Publish(It.IsAny<DomainNotification>(), 
                new System.Threading.CancellationToken()));
        }

        [Fact(DisplayName = "O Handle deve atualizar com sucesso a permissão.")]
        [Trait("Handler - Permissão", "AtualizarPermissão")]
        public async Task Handle_deve_cadastrar_com_sucesso()
        {
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            var commandFake = new AtualizarPermissaoCommand(Guid.NewGuid(),"Usuário", "Editar");
            var handle = new AtualizarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeTrue();
            commandFake.ValidationResult.Errors.Should().BeEmpty();
            _mediator.Verify(m => m.Publish(It.IsAny<PermissaoAtualizadaEvent>(), default), Times.Once());
        }
    }
}
