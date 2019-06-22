using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
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
    public class CancelarPermissoesPefilCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;
        private readonly Mock<IPerfilService> _service;

        public CancelarPermissoesPefilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new Mock<DomainNotificationHandler>();
            _service = new Mock<IPerfilService>();
        }

        [Fact(DisplayName = "O Handle deve verificar se comando invalido e retornar false.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_verificar_se_comando_invalido_e_retornar_false()
        {
            //arrange
            var perfilId = Guid.Empty;
            var listaPermissao = new List<PermissaoAssinadaDTO>();
            var command = new CancelarPermissoesPerfilCommand(perfilId, listaPermissao);
            var handle = new CancelarPermissoesPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object, 
                _service.Object, _perfilRepositoryMock.Object);
            var cancelToken = new System.Threading.CancellationToken();
            
            //act
            var result = await handle.Handle(command, cancelToken);
            
            //assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "O Handle deve retornar falso se o perfil não existir.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir()
        {
            //arrange
            var perfilId = Guid.NewGuid();
            var listaPermissao = new List<PermissaoAssinadaDTO>()
            {
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                    Status =  false
                },
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                    Status =  false
                },
            };

            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>()));

            var command = new CancelarPermissoesPerfilCommand(perfilId, listaPermissao);
            var handle = new CancelarPermissoesPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object,
                _service.Object, _perfilRepositoryMock.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handle.Handle(command, cancelToken);

            //assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "O Handle deve retornar falso e notificar erro caso nao possa cancelar permissão.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_falso_e_notificar_erro_caso_nao_possa_cancelar_permissao()
        {
            //arrange
            var perfilId = Guid.NewGuid();
            var permissao1 = Guid.NewGuid();
            var permissao2 = Guid.NewGuid();

            var listaPermissao = new List<PermissaoAssinadaDTO>()
            {
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = permissao1,
                    Status =  false
                },
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = permissao2,
                    Status =  false
                },
            };

            var perfil = TestBuilder.PerfilFalsoComPermissoes();
            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(perfil);
            _service.Setup(s => s.CancelarPermissoes(It.IsAny<List<PermissaoAssinada>>()))
              .ReturnsAsync((Perfil)null);
            var command = new CancelarPermissoesPerfilCommand(perfilId, listaPermissao);
            var handle = new CancelarPermissoesPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object,
                _service.Object, _perfilRepositoryMock.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handle.Handle(command, cancelToken);

            //assert
            result.Should().BeFalse();
            _mediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), default), Times.Once());
        }

        [Fact(DisplayName = "O handle deve retornar verdadeiro se cancelar com sucesso as permissões.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_verdadeiro_se_cancelar_com_sucesso_as_permissoes()
        {
            //arrange
            var perfilId = Guid.NewGuid();
            var permissao1 = Guid.NewGuid();
            var permissao2 = Guid.NewGuid();

            var listaPermissao = new List<PermissaoAssinadaDTO>()
            {
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = permissao1,
                    Status =  false
                },
                new PermissaoAssinadaDTO()
                {
                    PermissaoId = permissao2,
                    Status =  false
                },
            };

            var perfil = TestBuilder.PerfilFalsoComPermissoes();
            _perfilRepositoryMock.Setup(p => p.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(perfil);
            _service.Setup(s => s.CancelarPermissoes(It.IsAny<List<PermissaoAssinada>>()))
                .ReturnsAsync(perfil);

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            var command = new CancelarPermissoesPerfilCommand(perfilId, listaPermissao);
            var handle = new CancelarPermissoesPerfilCommandHandler(_mediator.Object, _uow.Object, _notifications.Object,
                _service.Object, _perfilRepositoryMock.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handle.Handle(command, cancelToken);

            //assert
            result.Should().BeTrue();
            _mediator.Verify(m => m.Publish(It.IsAny<PermissaoCanceladaEvent>(), default), Times.Once());
        }
    }
}
