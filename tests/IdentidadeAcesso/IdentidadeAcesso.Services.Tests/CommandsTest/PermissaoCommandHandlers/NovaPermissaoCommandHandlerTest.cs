using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
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
    public class NovaPermissaoCommandHandlerTest
    {

        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPermissaoRepository> _permissaoRepository;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;
        public NovaPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _permissaoRepository = new Mock<IPermissaoRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
        }

        [Fact(DisplayName = "O handle deve retornar false para comando inválido.")]
        [Trait("Handler - Permissão", "NovaPermissão")]
        public async Task Handle_deve_retornar_false_para_comando_invalido()
        {
            //arrange
            var commandFake = new CriarPermissaoCommand("","C", true);
            var handle = new CriarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            commandFake.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "O handle deve retornar false se comando com mesmo tipo e valor existir.")]
        [Trait("Handler - Permissão", "NovaPermissão")]
        public async Task Handle_deve_retornar_false_se_comando_com_mesmo_tipo_e_valor_existir()
        {
            //arrange
            var commandFake = new CriarPermissaoCommand("Usuário", "Criar", true);
            var listMock = new List<Permissao>()
            {
                TestBuilder.CriarPermissaoFake()
            };
            _permissaoRepository.Setup(r => r.Buscar(It.IsAny<Expression<Func<Permissao, bool>>>())).ReturnsAsync(listMock);

            var handle = new CriarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
            commandFake.ValidationResult.Errors.Should().BeEmpty();
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O Handle deve cadastrar com sucesso a permissão.")]
        [Trait("Handler - Permissão", "NovaPermissão")]
        public async Task Handle_deve_cadastrar_com_sucesso()
        {
            var commandFake = new CriarPermissaoCommand("Usuário", "Criar", true);
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            var handle = new CriarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeTrue();
            commandFake.ValidationResult.Errors.Should().BeEmpty();
            _mediator.Verify(m => m.Publish(It.IsAny<PermissaoCriadaEvent>(), default), Times.Once());
        }
    }
}
