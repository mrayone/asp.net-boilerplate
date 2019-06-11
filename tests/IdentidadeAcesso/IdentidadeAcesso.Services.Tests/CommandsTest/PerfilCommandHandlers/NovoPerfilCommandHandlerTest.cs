using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.Perfil;
using IdentidadeAcesso.API.Application.Commands.Perfil.Handlers;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.Tests.CommandsTest.PerfilCommandHandlers
{
    public class NovoPerfilCommandHandlerTest
    {

        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IPerfilRepository> _perfilRepositoryMock;
        private readonly Mock<IUnitOfWork> _uow;

        public NovoPerfilCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilRepositoryMock = new Mock<IPerfilRepository>();
            _uow = new Mock<IUnitOfWork>();
        }

        [Fact(DisplayName = "O Handle retorna falso se o perfil não for persistido.")]
        [Trait("Handler - Perfil", "NovoPerfil")]
        public async Task Handle_retorna_falso_se_o_perfil_estiver_invalidoAsync()
        {
            //arrange
            var command = FalsoPerfilRequestComPermissoes();
            _perfilRepositoryMock.Setup(perfil => perfil.ObterPorId(It.IsAny<Guid>())).Returns(PerfilFalso());
            var handler = new CriarPerfilCommandHandler(_mediator.Object, _perfilRepositoryMock.Object, _uow.Object);
            var cancelToken = new System.Threading.CancellationToken();

            //act
            var result = await handler.Handle(command, cancelToken);

            //assert
            result.Should().BeFalse();
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
                ) ;
        }
    }
}
