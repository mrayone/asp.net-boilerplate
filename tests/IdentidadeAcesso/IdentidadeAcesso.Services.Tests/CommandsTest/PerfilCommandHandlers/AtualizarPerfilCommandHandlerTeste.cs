using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
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

        /*
         * TODO:Testes ao atualizar perfil devem verificar estado de permissoes e do perfil.
         * Não pode cancelar uma assinatura que não foi assinada.
         * Não pode atualizar um perfil invalido.
         * Não pode atualizar um perfil com um nome existen.
         * 
         */ 

        [Fact(DisplayName = "O handle deve retornar falso se perfil invalido")]
        [Trait("Handler - Perfil", "AtualizarPerfil")]
        public async Task Handle_deve_retornar_falso_se_perfil_invalido()
        {

        }
    }
}
