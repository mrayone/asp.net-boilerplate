using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioQueries _usuarioQuereis;
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public UsuariosController(IUsuarioQueries usuarioQuereis, IMediator mediator,
            INotificationHandler<DomainNotification> notification)
        {
            _usuarioQuereis = usuarioQuereis;
            _mediator = mediator;
            _notifications = notification;
        }

        [Route("obter-todos")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuariosAsync()
        {
            var list = await _usuarioQuereis.ObterTodosAsync();

            return Ok(list);
        }
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuarioAsync(Guid id)
        {
            try
            {
                var usuario = await _usuarioQuereis.ObterPorIdAsync(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarUsuarioAsync([FromBody] NovoUsuarioCommand usuario)
        {
            var result = await _mediator.Send(usuario);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarUsuarioAsync([FromBody] AtualizarUsuarioCommand usuario)
        {

            var result = await _mediator.Send(usuario);

            return this.VerificarErros(_notifications, result);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirUsuarioAsync(Guid id)
        {
            var command = new ExcluirUsuarioCommand(id);

            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}