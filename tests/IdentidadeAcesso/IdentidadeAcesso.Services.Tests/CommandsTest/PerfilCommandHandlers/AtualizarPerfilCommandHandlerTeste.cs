using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers.Builders;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers
{
    public class AtualizarPerfilCommandHandlerTeste
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;

        public AtualizarPerfilCommandHandlerTeste()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();


            _perfilRepositoryMock.Setup(perfil => perfil.BuscarPorNome(TestBuilder.PerfilFalso().Identifacao.Nome)).Returns(TestBuilder.PerfilFalso());

            _perfilRepositoryMock.Setup(perfil => perfil.ObterPorId(It.IsAny<Guid>())).Returns(TestBuilder.PerfilFalso());
        }

        [Fact(DisplayName = "O handle deve retornar falso se perfil invalido")]
        [Trait("Handler - Perfil", "AtualizarPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_invalido()
        {
            //arrange
            var command = TestBuilder.FalsoAtualizarPerfilRequestComPermissoes();
            var handler = new AtulizarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "O Handle deve disparar evento se um perfil com mesmo nome ja existir.")]
        [Trait("Handler - Perfil", "AtualizarPerfil")]
        public async Task Handle_deve_disparar_evento_se_um_perfil_como_mesmo_nome_ja_existir()
        {
            var command = TestBuilder.FalsoPerfilRequestComNomeExistente();

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Fail);
            var handler = new AtulizarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
            result.Should().BeFalse();
        }
    }
}
