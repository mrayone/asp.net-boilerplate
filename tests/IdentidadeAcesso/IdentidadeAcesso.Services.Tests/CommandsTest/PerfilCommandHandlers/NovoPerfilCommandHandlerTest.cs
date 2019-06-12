using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.Tests.CommandsTest.PerfilCommandHandlers
{
    public class NovoPerfilCommandHandlerTest
    {

        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;

        public NovoPerfilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();

            
            _perfilRepositoryMock.Setup(perfil => perfil.BuscarPorNome(It.IsAny<string>())).Returns(PerfilFalso());

            _perfilRepositoryMock.Setup(perfil => perfil.ObterPorId(It.IsAny<Guid>())).Returns(PerfilFalso());

        }

        [Fact(DisplayName = "O Handle retorna falso se o perfil não for persistido.")]
        [Trait("Handler - Perfil", "NovoPerfil")]
        public async Task Handle_retorna_falso_se_o_perfil_estiver_invalidoAsync()
        {
            //arrange
            var command = FalsoPerfilRequestComPermissoes();
            var handler = new CriarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            result.Should().BeFalse();
        }


        [Fact(DisplayName = "O Handle deve disparar evento se um perfil com mesmo nome ja existir.")]
        [Trait("Handler - Perfil", "NovoPerfil")]
        public async Task Handle_deve_disparar_evento_se_um_perfil_como_mesmo_nome_ja_existir()
        {
            var command = FalsoPerfilRequestComNomeExistente();
            
            _uow.Setup(u => u.Commit()).Returns(CommandResponse.Fail);
            var handler = new CriarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.AtLeastOnce());
        }


        [Fact(DisplayName = "O Handle deve persistir um perfil com sucesso.")]
        [Trait("Handler - Perfil", "NovoPerfil")]
        public async Task Handle_deve_persistir_um_perfil_com_sucesso()
        {
            var command = FalsoPerfilRequestOk();
            _uow.Setup(u => u.Commit()).Returns(CommandResponse.Ok);

            var handler = new CriarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object, _notifications.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            result.Should().BeTrue();
        }

        private Perfil PerfilFalso()
        {
            var identificacao = new Identificacao("Perfil RH 01", "Perfil de acesso nível 1");
            return new Perfil(identificacao);
        }

        private CriarPerfilCommand FalsoPerfilRequestComPermissoes()
        {
            return new CriarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "1",
                descricao: "a",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid(),
                            Status = true
                        }
                    }
                );
        }

        private CriarPerfilCommand FalsoPerfilRequestComNomeExistente()
        {
            return new CriarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 01",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid(),
                            Status = true
                        }
                    }
                );
        }

        private CriarPerfilCommand FalsoPerfilRequestOk()
        {
            return new CriarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 02",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid(),
                            Status = true
                        }
                    }
                );
        }
    }
}
