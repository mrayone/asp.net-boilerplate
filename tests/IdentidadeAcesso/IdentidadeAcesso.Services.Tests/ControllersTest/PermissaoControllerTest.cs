﻿using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.UnitTests.ControllersTest
{
    public class PermissaoControllerTest
    {
        private readonly PermissoesController _controller;
        private readonly Mock<IPermissaoQueries> _permissaoQueries;
        private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notifications;
        private readonly Mock<IMediator> _mediator;
        private readonly IList<PermissaoViewModel> _list;
        public PermissaoControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _permissaoQueries = new Mock<IPermissaoQueries>();
            _notifications = new Mock<IDomainNotificationHandler<DomainNotification>>();

            _controller = new PermissoesController(_permissaoQueries.Object,
                _mediator.Object, _notifications.Object);
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
            _permissaoQueries.Setup(s => s.ObterTodasAsync())
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
            _permissaoQueries.Setup(s => s.ObterPorIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(permissaoViewModel);

            //act
            var result = await _controller.GetPermissaoAsync(Guid.NewGuid());
            var vr = result as OkObjectResult;
            //assert

            result.Should().BeAssignableTo<OkObjectResult>();
            vr.Value.Should().Be(permissaoViewModel);
        }

        [Fact(DisplayName = "Deve retornar notfound em obter permissão por Id.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_NotFound_Em_Obter_Permissao_Por_Id()
        {
            // arrange
            var permissaoViewModel = ViewModelBuilder.PermissaoViewFake();
            _permissaoQueries.Setup(s => s.ObterPorIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new KeyNotFoundException());

            //act
            var result = await _controller.GetPermissaoAsync(Guid.NewGuid());
            var vr = result as NotFoundResult;
            //assert

            result.Should().BeAssignableTo<NotFoundResult>();
            vr.StatusCode.Should().Be(404);
        }

        [Fact(DisplayName = "Deve retonar Ok ao persistir permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Ok_Ao_Persistir_Permissao()
        {
            //arrange
            var permissao = ViewModelBuilder.PermissaoViewFake();
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<bool>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(true);
            //act
            var result = await _controller.CriarPermissaoAsync(permissao);

            //assert
            result.Should().BeAssignableTo<OkResult>();
            var vr = result as OkResult;
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact(DisplayName = "Deve retonar BadRequest ao criar permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_BadRequest_Ao_Criar_Permissao()
        {
            //arrange
            var permissao = ViewModelBuilder.PermissaoViewFake();

            //act
            var result = await _controller.CriarPermissaoAsync(permissao);

            //assert
            result.Should().BeAssignableTo<BadRequestResult>();
            var vr = result as BadRequestResult;
            vr.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact(DisplayName = "Deve retonar Ok ao editar permissão.")]
        [Trait("Controller", "Permissão")]
        public async Task Deve_Retornar_Ok_Ao_Editar_Permissao()
        {
            //arrange
            var permissao = ViewModelBuilder.PermissaoViewFake();
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<bool>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(true);
            //act
            var result = await _controller.AtualizarPermissaoAsync(permissao);

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
            _mediator.Setup(s => s.Send(It.IsAny<IRequest<bool>>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(true);
            //act
            var result = await _controller.ExcluirPermissaoAsync(Guid.NewGuid());

            //assert
            result.Should().BeAssignableTo<OkResult>();
            var vr = result as OkResult;
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}