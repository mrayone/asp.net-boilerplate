using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using IdentidadeAcesso.API.Controllers.Extensions;
using IdentidadeAcesso.CrossCutting.Identity.CustomAuthorizeAttribute;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notifications;
        private readonly IHttpContextAccessor _httpAcessor;

        public UsuariosController(IMediator mediator,
            INotificationHandler<DomainNotification> notification, IHttpContextAccessor httpAcessor)
        {
            _mediator = mediator;
            _notifications = notification;
            _httpAcessor = httpAcessor;
        }

        /// <summary>
        /// Lista todos os usuários. Este método requer permissão para "Visualizar Usuários".
        /// </summary>
        ///
        [Route("obter-todos")]
        [PermissaoAuthorize("Visualizar Usuários")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuariosAsync()
        {
            var list = await _mediator.Send(new BuscarTodos<UsuarioViewModel>());

            return Ok(list);
        }

        /// <summary>
        /// Obtém um usuário por Id. Este método requer permissão para "Visualizar Usuários".
        /// </summary>
        ///
        [HttpGet("{id:Guid}")]
        [PermissaoAuthorize("Visualizar Usuários")]
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuarioAsync(Guid id)
        {
            var usuario = await _mediator.Send(new BuscarPorId<UsuarioViewModel>(id));
            return Ok(usuario);
        }

        /// <summary>
        /// Retorna as informações do usuário autenticado.
        /// </summary>
        ///
        [HttpGet("info")]
        [Authorize]
        [ProducesResponseType(typeof(UsuarioViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInfoUsuarioAsync()
        {
            try
            {
                var claimValue = _httpAcessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub");
                var usuario = await _mediator.Send(new BuscarPorId<UsuarioViewModel>(new Guid(claimValue.Value)));
                return Ok(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Cria um novo usuário no sistema e com tipo de perfil específicado. Este método requer permissão para "Criar Usuário".
        /// </summary>
        ///
        [HttpPost]
        [PermissaoAuthorize("Criar Usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarUsuarioAsync([FromBody] NovoUsuarioCommand usuario)
        {
            var result = await _mediator.Send(usuario);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Atualiza um usuário no sistema e com tipo de perfil específicado. Este método requer permissão para "Atualizar Usuário".
        /// </summary>
        ///
        [HttpPut]
        [PermissaoAuthorize("Atualizar Usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarUsuarioAsync([FromBody] AtualizarUsuarioCommand usuario)
        {

            var result = await _mediator.Send(usuario);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Solicitar nova senha em caso de esquecimento.
        /// </summary>
        ///
        [HttpPost("esqueci-a-senha")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SolicitacaoDeNovaSenhaAsync([FromBody] SolicitarNovaSenhaCommand command)
        {

            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Redefine a senha do usuário através do token fornecido. url/redefinir-senha?token=TOKEN_GERADO
        /// </summary>
        ///
        [HttpPut("redefinir-senha/{token}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RedefinirSenhaAsync([FromBody] RedefinirSenhaViewModel model, string token)
        {
            var command = new DefinirNovaSenhaPorTokenCommand(token, model.Email, model.Senha, model.ConfirmaSenha);
            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Possibilita a alteração de senha do usuário logado.
        /// </summary>
        ///
        [HttpPut("trocar-senha")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> TrocarSenha([FromBody] TrocarSanhaViewModel model)
        {
            var claimValue = _httpAcessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub");

            var command = new TrocarSenhaCommand(new Guid(claimValue.Value), model.SenhaAtual, model.Senha, model.ConfirmaSenha);

            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Atualiza os dados do usuário logado. Este método requer estar logado.
        /// </summary>
        ///
        [HttpPut("atualizar-perfil")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarPerfilUsuarioAsync([FromBody] AtualizarPerfilUsuarioViewModel usuario)
        {
            var claimValue = _httpAcessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub");

            var command = new AtualizarPerfilUsuarioCommand(new Guid(claimValue.Value), usuario.Nome, usuario.Sobrenome, usuario.Sexo, usuario.Email, usuario.CPF, usuario.DataDeNascimento,
                usuario.Telefone, usuario.Celular, usuario.Logradouro, usuario.Numero, usuario.Complemento, usuario.Bairro, usuario.CEP, usuario.Cidade, usuario.Estado);

            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }

        /// <summary>
        /// Exclui um usuário do sistema. Este método requer permissão para "Excluir Usuário".
        /// </summary>
        ///
        [HttpDelete("{id:Guid}")]
        [PermissaoAuthorize("Excluir Usuário")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirUsuarioAsync(Guid id)
        {
            var command = new ExcluirUsuarioCommand(id);

            var result = await _mediator.Send(command);

            return this.VerificarErros(_notifications, result);
        }
    }
}