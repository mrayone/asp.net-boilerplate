using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class ExcluirUsuarioValidation : AbstractValidator<ExcluirUsuarioCommand>
    {
        public ExcluirUsuarioValidation()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }
    }
}
