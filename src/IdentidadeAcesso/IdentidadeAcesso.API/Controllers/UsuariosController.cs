using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioQueries _usuarioQuereis;
        private readonly IMediator _mediator;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public UsuariosController(IUsuarioQueries usuarioQuereis, IMediator mediator,
            IDomainNotificationHandler<DomainNotification> notification)
        {
            _usuarioQuereis = usuarioQuereis;
            _mediator = mediator;
            _notification = notification;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuariosAsync()
        {
            var list = await _usuarioQuereis.ObterTodosAsync();

            return Ok(list);
        }
    }
}