using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentidadeAcesso.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{ver:apiVersion}/permissoes")]
    [ApiController]
    public class PermissoesController : ControllerBase
    {
        private readonly IPermissaoQueries _permissaoQueries;
        private readonly IMediator _mediator;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public PermissoesController( IPermissaoQueries permissoQueries, IMediator mediator, 
            IDomainNotificationHandler<DomainNotification> notification )
        {
            _permissaoQueries = permissoQueries;
            _mediator = mediator;
            _notification = notification;
        }

        [Route("obter-todas")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PermissaoViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPermissoesAsync()
        {
            var list = await _permissaoQueries.ObterTodasAsync();

            return Ok(list);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PermissaoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPermissaoAsync(Guid id)
        {
            try
            {
                var model = await _permissaoQueries.ObterPorIdAsync(id);
                return Ok(model);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPermissaoAsync([FromBody] PermissaoViewModel model)
        {
            var command = new CriarPermissaoCommand(model.Tipo, model.Valor);
            var result = await _mediator.Send(command).ConfigureAwait(false);

            if(result)
            {
                return Ok();
            }

            return BadRequest(_notification.GetNotifications());
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPermissaoAsync([FromBody] PermissaoViewModel model)
        {
            var command = new AtualizarPermissaoCommand(model.Id, model.Tipo, model.Valor);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }

            return this.NotificarDomainErros(_notification);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirPermissaoAsync( Guid id )
        {
            var command = new ExcluirPermissaoCommand(id);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }

            return this.NotificarDomainErros(_notification);
        }
    }
}
