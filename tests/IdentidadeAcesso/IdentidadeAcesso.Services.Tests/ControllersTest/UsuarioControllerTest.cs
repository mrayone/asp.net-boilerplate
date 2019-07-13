﻿using FluentAssertions;
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
    public class UsuarioControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUsuarioQueries> _usuarioQueries;
        private readonly Mock<IDomainNotificationHandler<DomainNotification>> _notifications;
        private readonly UsuariosController _controller;
        public UsuarioControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _usuarioQueries = new Mock<IUsuarioQueries>();
            _notifications = new Mock<IDomainNotificationHandler<DomainNotification>>();

            _controller = new UsuariosController(_usuarioQueries.Object, _mediator.Object,
                _notifications.Object);
        }

        [Trait("Controller","UsuariosController")]
        [Fact(DisplayName = "Deve retornar lista de usuários cadastrados.")]
        public async Task Deve_Retornar_Lista_De_Usuarios_Cadastrados()
        {
            //arrange
            var list = new List<UsuarioViewModel>()
            {
                ViewModelBuilder.UsuarioFake(),
                ViewModelBuilder.UsuarioFake(),
                ViewModelBuilder.UsuarioFake(),
            };
            _usuarioQueries.Setup(q => q.ObterTodosAsync())
                .ReturnsAsync(list);
            //act
            var result = await _controller.GetUsuariosAsync();

            //assert
            result.Should().BeAssignableTo<OkObjectResult>();
            var vr = result as OkObjectResult;
            vr.Value.Should().Be(list);
            vr.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Trait("Controller", "UsuariosController")]
        [Fact(DisplayName = "Deve retonar um usuário ao passar o Id por parametro.")]
        public async Task Deve_Retornar_Um_Usuario_Ao_Passar_O_Id_Por_Parametro()
        {

        }
    }
}