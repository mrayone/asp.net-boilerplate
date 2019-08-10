using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.CrossCutting.Identity.CustomAuthorizeAttribute;
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

        /// <summary>
        /// Lista todos as permissões. Este método requer permissão para "Visualizar Permissões".
        /// </summary>
        ///
        [HttpGet("obter-todas")]
        [PermissaoAuthorize("Visualizar Permissões")]
        [ProducesResponseType(typeof(IEnumerable<PermissaoViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPermissoesAsync()
        {
            var list = await _mediator.Send(new BuscarTodos<PermissaoViewModel>());

            return Ok(list);
        }

        /// <summary>
        /// Obtém um permissão por Id. Este método requer permissão para "Visualizar Permissões".
        /// </summary>
        ///
        [HttpGet("{id:Guid}")]
        [PermissaoAuthorize("Visualizar Permissões")]
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

        /// <summary>
        /// Cria uma permissão no sistema. Este método requer permissão para "Criar Permissão".
        /// </summary>
        ///
        [HttpPost]
        [PermissaoAuthorize("Criar Permissão")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPermissaoAsync([FromBody] CriarPermissaoCommand criarPermissao)
        {
            var result = await _mediator.Send(criarPermissao);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Atualiza uma permissão do sistema. Este método requer permissão para "Atualizar Permissão".
        /// </summary>
        ///
        [HttpPut]
        [PermissaoAuthorize("Editar Permissão")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPermissaoAsync([FromBody] AtualizarPermissaoCommand atualizarPermissao)
        {
            var result = await _mediator.Send(atualizarPermissao);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Exclui uma permissão do sistema. Este método requer permissão para "Excluir Permissão".
        /// </summary>
        //
        [HttpDelete("{id:Guid}")]
        [PermissaoAuthorize("Excluir Permissão")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirPermissaoAsync( Guid id )
        {
            var command = new ExcluirPermissaoCommand(id);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}
