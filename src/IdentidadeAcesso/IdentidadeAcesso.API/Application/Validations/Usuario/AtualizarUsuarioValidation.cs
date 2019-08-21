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
        public AtualizarUsuarioValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O ID do usuário tem que ser fornecido.");

            RuleFor(c => c.PerfilId)
            .NotEqual(Guid.Empty)
            .WithMessage("O ID do perfil tem que ser fornecido.");
        }
    }
}
