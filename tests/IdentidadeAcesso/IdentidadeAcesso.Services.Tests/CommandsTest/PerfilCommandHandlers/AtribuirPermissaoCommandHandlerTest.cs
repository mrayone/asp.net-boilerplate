using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers.Builder;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers
{
    public class AtribuirPermissaoCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IPerfilService> _service;
        private readonly AtribuirPermissaoCommandHandler _handler;
        private readonly List<AtribuicaoDTO> _list;

        public AtribuirPermissaoCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
            _notifications = new DomainNotificationHandler();

            _service = new Mock<IPerfilService>();
            _handler = new AtribuirPermissaoCommandHandler(_mediator.Object, _uow.Object, 
                _notifications, _service.Object, _perfilRepositoryMock.Object);

            _perfilRepositoryMock.Setup(r => r.ObterComPermissoesAsync(It.IsAny<Guid>()))
                .ReturnsAsync(TestBuilder.PerfilFalso());

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);

            _list = new List<AtribuicaoDTO>()
            {
                new AtribuicaoDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                    Ativo = true
                    
                },
                new AtribuicaoDTO()
                {
                    PermissaoId = Guid.NewGuid(),
                    Ativo = true
                }
            };
        }

        [Fact(DisplayName = "Deve assinar permissão e retornar true .")]
        [Trait("Handler - Perfil", "AtribuirPermissaoCommand")]
        public async Task Deve_AssinarPermissao_e_Retornar_True()
        {
            //arrange
            var perfil = TestBuilder.PerfilFalso();
            _service.Setup(s => s.AtribuirPermissaoAsync(It.IsAny<Perfil>(), It.IsAny<Guid>()))
                .ReturnsAsync(perfil);
            var command = new AtribuirPermissaoCommand(perfil.Id, _list);
            //act
            var result = await _handler.Handle(command, new System.Threading.CancellationToken());
            //assert
            result.Success.Should().BeTrue();
            _service.Verify(s => s.AtribuirPermissaoAsync(perfil, It.IsAny<Guid>()), Times.Once);
            _uow.Verify(u => u.Commit(), Times.Once);
        }

        [Fact(DisplayName = "O Handle deve retornar falso se o perfil não existir.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_falso_se_perfil_nao_existir()
        {
            //arrange
            var perfilId = Guid.NewGuid();
            _perfilRepositoryMock.Setup(r => r.ObterComPermissoesAsync(It.IsAny<Guid>()))
                                .ReturnsAsync((Perfil) null);

            var command = new AtribuirPermissaoCommand(perfilId, _list);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await _handler.Handle(command, cancelToken);

            //assert
            result.Success.Should().BeFalse();
        }

        [Fact(DisplayName = "O handle deve retornar verdadeiro se cancelar com sucesso as permissões.")]
        [Trait("Handler - Perfil", "CancelarPermissão")]
        public async Task Handle_deve_retornar_verdadeiro_se_cancelar_com_sucesso_as_permissoes()
        {
            //arrange
            var permissao1 = Guid.NewGuid();
            var permissao = _list.FirstOrDefault();
            permissao.Ativo = false;

            var perfil = TestBuilder.PerfilFalso();
            _perfilRepositoryMock.Setup(p => p.ObterComPermissoesAsync(It.IsAny<Guid>())).ReturnsAsync(perfil);
            _service.Setup(s => s.RevogarPermissaoAsync(It.IsAny<Perfil>(), It.IsAny<Guid>()))
                .ReturnsAsync(perfil);

            _uow.Setup(u => u.Commit()).ReturnsAsync(CommandResponse.Ok);
            var command = new AtribuirPermissaoCommand(perfil.Id, _list);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await _handler.Handle(command, cancelToken);

            //assert
            result.Success.Should().BeTrue();
            _mediator.Verify(m => m.Publish(It.IsAny<PermissaoAssinadaEvent>(), default), Times.Once());
        }
    }
}
