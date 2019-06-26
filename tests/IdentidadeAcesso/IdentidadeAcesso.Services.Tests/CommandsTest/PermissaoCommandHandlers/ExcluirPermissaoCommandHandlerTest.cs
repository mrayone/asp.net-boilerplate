using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
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
        private readonly Mock<DomainNotificationHandler> _notifications;
        private readonly Mock<IPermissaoService> _service;
        private readonly ExcluirPermissaoCommandHandler _handler;
        public ExcluirPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _permissaoRepository = new Mock<IPermissaoRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
            _service = new Mock<IPermissaoService>();
            _handler = new ExcluirPermissaoCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, _permissaoRepository.Object , _service.Object);
        }

        [Trait("Handler - Permissão", "ExcluirPermissão")]
        [Fact(DisplayName = "O handle deve excluir a permissão e retornar true.")]
        public async Task Handle_deve_excluir_permissao_e_retornar_true()
        {
            //arrange
            var command = new ExcluirPermissaoCommand(Guid.NewGuid());
            _permissaoRepository.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(PermissaoBuilder.CriarPermissaoFake());
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());

            //assert
            result.Should().BeTrue();
        }
    }
}
