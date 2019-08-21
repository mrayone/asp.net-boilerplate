using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Domain.SeedOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class SolicitarNovaSenhaCommand : IRequest<CommandResponse>
    {
        public SolicitarNovaSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }
    }
}
