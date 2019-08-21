using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers;
using IdentidadeAcesso.Domain.SeedOfWork;
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
    public class PermissaoControllerTest
    {
        private readonly PermissoesController _controller;
        private readonly DomainNotificationHandler _notifications;
        private readonly Mock<IMediator> _mediator;
        private readonly IList<PermissaoViewModel> _list;
        public PermissaoControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _notifications = new DomainNotificationHandler();
            _controller = new PermissoesController(_mediator.Object, _notifications);
            _list = new List<PermissaoViewModel>()
            {
                ViewModelBuilder.PermissaoViewFake(),
                ViewModelBuilder.PermissaoViewFake(),
                ViewModelBuilder.PermissaoViewFake(),
                ViewModelBuilder.PermissaoViewFake(),
            };
        }

        [Fact(DisplayName = "Deve retornar uma lista de permissões")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Lista_De_Permissoes()
        {
            // arrange
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<IEnumerable<PermissaoViewModel>>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(_list);

            //act
            var result = await _controller.GetPermissoesAsync();
            var vr = result as OkObjectResult;
            //assert

            result.Should().BeAssignableTo<OkObjectResult>();
            vr.Value.Should().Be(_list);
        }

        [Fact(DisplayName = "Deve Retornar uma permissão em caso de Get Por Id")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Uma_Permissao_Por_Id()
        {
            // arrange
            var permissaoViewModel = ViewModelBuilder.PermissaoViewFake();
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<PermissaoViewModel>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(permissaoViewModel);

            //act
            var result = await _controller.GetPermissaoAsync(Guid.NewGuid());
            var vr = result as OkObjectResult;
            //assert

            result.Should().BeAssignableTo<OkObjectResult>();
            vr.Value.Should().Be(permissaoViewModel);
        }

        [Fact(DisplayName = "Deve retonar Ok ao persistir permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Ok_Ao_Persistir_Permissao()
        {
            //arrange
            var permissao = ViewModelBuilder.PermissaoViewFake();
            var command = new CriarPermissaoCommand(permissao.Tipo, permissao.Valor);
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<CommandResponse>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(CommandResponse.Ok).Verifiable();
            //act
            var result = await _controller.CriarPermissaoAsync(command);

            //assert
            result.Should().BeAssignableTo<OkResult>();
            var vr = result as OkResult;
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
            _mediator.Verify();
        }

        [Fact(DisplayName = "Deve retonar BadRequest ao criar permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_BadRequest_Ao_Criar_Permissao()
        {
            //arrange
            var permissao = ViewModelBuilder.PermissaoViewFake();
            var command = new CriarPermissaoCommand(permissao.Tipo, permissao.Valor);
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<CommandResponse>>(), new System.Threading.CancellationToken()))
            .ReturnsAsync(CommandResponse.Fail.AddError("Erro Fake")).Verifiable();
            //act
            var result = await _controller.CriarPermissaoAsync(command);

            //assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            var vr = result as BadRequestObjectResult;
            vr.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact(DisplayName = "Deve retonar Ok ao editar permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Ok_Ao_Editar_Permissao()
        {
            //arrange
            var permissao = ViewModelBuilder.PermissaoViewFake();
            var command = new AtualizarPermissaoCommand(permissao.Id, permissao.Tipo, permissao.Valor);
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<CommandResponse>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(CommandResponse.Ok);
            //act
            var result = await _controller.AtualizarPermissaoAsync(command);

            //assert
            result.Should().BeAssignableTo<OkResult>();
            var vr = result as OkResult;
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact(DisplayName = "Deve retonar Ok ao excluir permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Ok_Ao_Deletar_Permissao()
        {
            //arrange
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<CommandResponse>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(CommandResponse.Ok);
            //act
            var result = await _controller.ExcluirPermissaoAsync(Guid.NewGuid());

            //assert
            result.Should().BeAssignableTo<OkResult>();
            var vr = result as OkResult;
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
