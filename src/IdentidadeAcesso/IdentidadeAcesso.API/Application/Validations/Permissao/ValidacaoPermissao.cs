using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Permissao
{
    public abstract class ValidacaoPermissao<T> : AbstractValidator<T> where T: BasePermissaoCommand<T>
    {
        public ValidacaoPermissao()
        {
            RuleFor(c => c.Tipo)
                .MaximumLength(50)
                .MinimumLength(2);

            RuleFor(c => c.Valor)
                .MaximumLength(50)
                .MinimumLength(2);
        }
    }
}
