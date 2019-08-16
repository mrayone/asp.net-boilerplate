using IdentidadeAcesso.Domain.SeedOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class DefinirNovaSenhaPorTokenCommand : IRequest<CommandResponse>
    {
        public DefinirNovaSenhaPorTokenCommand(string token, string email, string senha, string confirmaSenha)
        {
            Token = token;
            Email = email;
            Senha = senha;
            ConfirmaSenha = confirmaSenha;
        }

        public string Token { get; }
        public string Email { get; }
        public string Senha { get; }
        public string ConfirmaSenha { get; }
    }
}
