using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentidadeAcesso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissoesController : ControllerBase
    {
        private readonly IPermissaoQueries _permissaoQueries;
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notification;

        public PermissoesController( IPermissaoQueries permissoQueries, IMediator mediator, INotificationHandler<DomainNotification> notification )
        {
            _permissaoQueries = permissoQueries;
            _mediator = mediator;
            _notification = notification;
        }

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
        public async Task<IActionResult> GetPermissaoAsync(Guid guid)
        {
            try
            {
                var model = await _permissaoQueries.ObterPorIdAsync(guid);
                return Ok(model);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPermissaoAsync([FromBody] CriarPermissaoCommand command)
        {
            var result = await _mediator.Send(command);

            if(result)
            {
                return Ok();
            }

            return this.NotificarDomainErros(_notification);
        }
    }
}
