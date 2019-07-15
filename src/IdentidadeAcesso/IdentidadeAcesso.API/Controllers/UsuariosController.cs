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

        [Route("obter-todos")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsuariosAsync()
        {
            var list = await _usuarioQuereis.ObterTodosAsync();

            return Ok(list);
        }
        [HttpGet]
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
        public async Task<IActionResult> CriarUsuarioAsync([FromBody] UsuarioViewModel usuario)
        {
            var command = new NovoUsuarioCommand(usuario.Nome, usuario.Sobrenome, usuario.Sexo, usuario.Email, usuario.CPF,
                usuario.DateDeNascimento, usuario.Telefone, usuario.Celular, usuario.Logradouro, usuario.Numero,
                usuario.Complemento, usuario.Bairro, usuario.CEP, usuario.Cidade, usuario.Estado, usuario.PerfilId);

            var result = await _mediator.Send(command);

            if(result.Success)
            {
                return Ok();
            }

            return this.NotificarDomainErros(_notification);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AtualizarUsuarioAsync([FromBody] UsuarioViewModel usuario)
        {
            var command = new AtualizarUsuarioCommand(usuario.Id, usuario.Nome, usuario.Sobrenome, usuario.Sexo, usuario.Email, usuario.CPF,
                usuario.DateDeNascimento, usuario.Telefone, usuario.Celular, usuario.Logradouro, usuario.Numero,
                usuario.Complemento, usuario.Bairro, usuario.CEP, usuario.Cidade, usuario.Estado, usuario.PerfilId);

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok();
            }

            return this.NotificarDomainErros(_notification);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ExcluirUsuarioAsync(Guid id)
        {
            var command = new ExcluirUsuarioCommand(id);

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok();
            }

            return this.NotificarDomainErros(_notification);
        }
    }
}