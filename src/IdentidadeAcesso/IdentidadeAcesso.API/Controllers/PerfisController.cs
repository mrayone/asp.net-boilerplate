using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
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

        [HttpGet]
        [ProducesResponseType(typeof(PermissaoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPerfilAsync(Guid guid)
        {
            try
            {
                var model = await _perfilQueris.ObterPorIdAsync(guid);
                return Ok(model);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("cancelar-permissoes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelarPermissoesAsync([FromBody] PermissaoAssinadaDTO permissao)
        {
            var command = new CancelarPermissaoCommand(permissao.PerfilId, permissao.PermissaoId);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPerfilAsync([FromBody] PerfilViewModel perfil)
        {
            var command = new CriarPerfilCommand(perfil.Nome, perfil.Descricao, perfil.Status);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPerfilAsync([FromBody] PerfilViewModel perfil)
        {
            var command = new AtualizarPerfilCommand(perfil.Id, perfil.Nome,
                perfil.Descricao, perfil.Status);

            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirPerfilAsync([FromBody] Guid id)
        {
            var command = new ExcluirPerfilCommand(id);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}