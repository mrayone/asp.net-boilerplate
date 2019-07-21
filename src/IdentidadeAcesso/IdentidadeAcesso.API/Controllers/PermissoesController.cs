using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
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
    [Route("api/v{ver:apiVersion}/permissoes")]
    [ApiController]
    public class PermissoesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public PermissoesController( IMediator mediator,
            INotificationHandler<DomainNotification> notification )
        {
            _mediator = mediator;
            _notifications = notification;
        }

        [HttpGet("obter-todas")]
        [ProducesResponseType(typeof(IEnumerable<PermissaoViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPermissoesAsync()
        {
            var list = await _mediator.Send(new BuscarTodos<IEnumerable<PermissaoViewModel>>());

            return Ok(list);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(PermissaoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPermissaoAsync(Guid id)
        {
            try
            {
                var model = await _mediator.Send(new BuscarPorId<PermissaoViewModel>(id));
                return Ok(model);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPermissaoAsync([FromBody] CriarPermissaoCommand criarPermissao)
        {
            var result = await _mediator.Send(criarPermissao);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPermissaoAsync([FromBody] AtualizarPermissaoCommand atualizarPermissao)
        {
            var result = await _mediator.Send(atualizarPermissao);

            return this.VerificarErros(_notifications, result);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirPermissaoAsync( Guid id )
        {
            var command = new ExcluirPermissaoCommand(id);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}
