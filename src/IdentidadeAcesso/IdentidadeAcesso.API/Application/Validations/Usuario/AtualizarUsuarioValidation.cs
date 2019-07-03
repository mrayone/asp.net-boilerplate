using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class AtualizarUsuarioValidation : ValidacaoUsuario<AtualizarUsuarioCommand>
    {
        public AtualizarUsuarioValidation() : base ()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O ID do usuário tem que ser fornecido.");
        }
    }
}
