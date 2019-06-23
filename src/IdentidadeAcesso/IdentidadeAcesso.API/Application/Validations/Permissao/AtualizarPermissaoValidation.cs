using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Permissao
{
    public class AtualizarPermissaoValidation : ValidacaoPermissao<AtualizarPermissaoCommand>
    {
        public AtualizarPermissaoValidation() : base()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }
    }
}
