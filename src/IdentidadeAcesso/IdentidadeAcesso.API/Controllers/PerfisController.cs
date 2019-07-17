using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/perfis")]
    [ApiController]
    public class PerfisController : ControllerBase
    {
        private readonly IPerfilQueries _perfilQueris;
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public PerfisController( IPerfilQueries perfilQueries, 
            IMediator mediator, INotificationHandler<DomainNotification> notifications )
        {
            _perfilQueris = perfilQueries;
            _mediator = mediator;
            _notifications = notifications;
        }

        [HttpGet("obter-todos")]
        [ProducesResponseType(typeof(IEnumerable<PerfilViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPerfisAsync()
        {
            var list = await _perfilQueris.ObterTodasAsync();

            return Ok(list);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(PerfilViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPerfilAsync(Guid id)
        {
            try
            {
                var model = await _perfilQueris.ObterPorIdAsync(id);
                return Ok(model);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPut("cancelar-permissao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelarPermissoesAsync([FromBody] CancelarPermissaoCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPut("assinar-permissao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AssinarPermissaoAsync([FromBody] AssinarPermissaoCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPerfilAsync([FromBody] CriarPerfilCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPerfilAsync([FromBody] AtualizarPerfilCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirPerfilAsync([FromBody] Guid id)
        {
            var command = new ExcluirPerfilCommand(id);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}