using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.CrossCutting.Identity.CustomAuthorizeAttribute;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public PerfisController( IMediator mediator, INotificationHandler<DomainNotification> notifications )
        {
            _mediator = mediator;
            _notifications = notifications;
        }
        /// <summary>
        /// Lista todos os perfis. Este método requer permissão para "Visualizar Perfis".
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de objetos PerfilViewModel.
        /// </remarks>
        [HttpGet("obter-todos")]
        [PermissaoAuthorize("Visualizar Perfis")]
        [ProducesResponseType(typeof(IEnumerable<PerfilViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPerfisAsync()
        {
            var list = await _mediator.Send(new BuscarTodos<PerfilViewModel>());

            return Ok(list);
        }

        /// <summary>
        /// Obtém um perfil por Id. Este método requer permissão para "Visualizar Perfis".
        /// </summary>
        /// <remarks>
        /// Retorna um objeto PerfilViewModel caso o mesmo exista na base de dados com o Id fornecido.
        /// </remarks>
        [HttpGet("{id:Guid}")]
        [PermissaoAuthorize("Visualizar Perfis")]
        [ProducesResponseType(typeof(PerfilViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPerfilAsync(Guid id)
        {
            try
            {
                var model = await _mediator.Send(new BuscarPorId<PerfilViewModel>(id));
                return Ok(model);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Revoga permissões atribuidas a um perfil. Este método requer permissão para "Revogar Permissões".
        /// </summary>
        [HttpPut("cancelar-permissao")]
        [PermissaoAuthorize("Revogar Permissões")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelarPermissoesAsync([FromBody] CancelarPermissaoCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Atribui permissões a um perfil. Este método requer permissão para "Atribuir Permissões".
        /// </summary>
        [HttpPut("assinar-permissao")]
        [PermissaoAuthorize("Atribuir Permissões")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AssinarPermissaoAsync([FromBody] AssinarPermissaoCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Cria um novo perfil. Este método requer permissão para "Criar Perfil".
        /// </summary>
        [HttpPost]
        [PermissaoAuthorize("Criar Perfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPerfilAsync([FromBody] CriarPerfilCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Edita um perfil do app. Este método requer permissão para "Editar Perfil".
        /// </summary>
        [HttpPut]
        [PermissaoAuthorize("Editar Perfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPerfilAsync([FromBody] AtualizarPerfilCommand command)
        {
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Exclui um perfil do app. Este método requer permissão para "Excluir Perfil".
        /// </summary>
        [HttpDelete("{id:Guid}")]
        [PermissaoAuthorize("Excluir Perfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirPerfilAsync(Guid id)
        {
            var command = new ExcluirPerfilCommand(id);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}