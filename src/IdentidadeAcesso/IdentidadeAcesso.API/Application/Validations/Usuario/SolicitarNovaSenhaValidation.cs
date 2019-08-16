using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class SolicitarNovaSenhaValidation : AbstractValidator<SolicitarNovaSenhaCommand>
    {
        public SolicitarNovaSenhaValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
        }
    }
}
