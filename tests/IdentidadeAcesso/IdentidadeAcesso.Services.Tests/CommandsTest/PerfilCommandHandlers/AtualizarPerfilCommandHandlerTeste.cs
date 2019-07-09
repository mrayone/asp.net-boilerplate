using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers.Builder;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers
{
    public class AtualizarPerfilCommandHandlerTeste
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notifications;
        private readonly IList<Perfil> _listMock;

        public AtualizarPerfilCommandHandlerTeste()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<IDomainNotificationHandler<DomainNotification>>();


            _listMock = new List<Perfil>()
            {
                TestBuilder.PerfilFalso()
            };

            _perfilRepositoryMock.Setup(perfil => perfil.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(TestBuilder.PerfilFalso());
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

            _perfilRepositoryMock.Setup(perfil => perfil.Buscar(It.IsAny<Expression<Func<Perfil, bool>>>()))
            .ReturnsAsync(_listMock);

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Fail);
            var handler = new AtulizarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "O Handle deve persistir um perfil com sucesso.")]
        [Trait("Handler - Perfil", "AtualizarPerfil")]
        public async Task Handle_deve_persistir_um_perfil_com_sucesso()
        {
            var command = TestBuilder.AtualizarPerfilRequestOk();
            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);

            var handler = new AtulizarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            result.Should().BeTrue();
        }
    }
}
