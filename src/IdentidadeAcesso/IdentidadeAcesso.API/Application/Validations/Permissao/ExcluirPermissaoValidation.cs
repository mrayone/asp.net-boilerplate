using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Permissao
{
    public class ExcluirPermissaoValidation : AbstractValidator<ExcluirPermissaoCommand>
    {
        public ExcluirPermissaoValidation()
        {
            RuleFor(c => c.PermissaoId).NotEqual(Guid.Empty).WithMessage("É necessário fornecer o ID da permissão.");
        }
    }
}
