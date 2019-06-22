using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
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
            var commandFake = new CriarPermissaoCommand("","Ca", true);
            var handle = new CriarPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object);
            //act
            var result = await handle.Handle(commandFake, new System.Threading.CancellationToken());
            //assert
            result.Should().BeFalse();
        }
    }
}
