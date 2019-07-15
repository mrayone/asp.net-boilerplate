using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.ControllersTest
{
    public class PerfilControllerTest
    {
        private readonly PerfisController _controller;
        private readonly Mock<IPerfilQueries> _perfilQueries;
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IMediator> _mediator;

        public PerfilControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _perfilQueries = new Mock<IPerfilQueries>();
            _notifications = new DomainNotificationHandler();

            _controller = new PerfisController(_perfilQueries.Object,
                _mediator.Object, _notifications);
        }

        [Fact(DisplayName = "Deve cancelar permissões assinadas e retornar Ok.")]
        [Trait("Controller","Perfil")]
        public async Task Deve_Cancelar_Permissoes_e_Retornar_Ok()
        {
            //arrange
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<CommandResponse>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(CommandResponse.Ok).Verifiable();
            var permissao = new PermissaoAssinadaDTO
            {
                PermissaoId = Guid.NewGuid(),
                PerfilId = Guid.NewGuid(),
                Status = true
            };

            //act
            var result = await _controller.CancelarPermissoesAsync(permissao);

            //assert
            result.Should().BeAssignableTo<OkResult>();
            var vr = result as OkResult;
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
