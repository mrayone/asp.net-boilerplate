using IdentidadeAcesso.API.Application.Validations.Permissao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public class ExcluirPermissaoCommand : BasePermissaoCommand<ExcluirPermissaoCommand>, IRequest<bool>
    {
        public ExcluirPermissaoCommand(Guid permissaoId)
        {
            PermissaoId = permissaoId;
        }

        public Guid PermissaoId { get; private set; }

        public override bool isValid()
        {
            ValidationResult = new ExcluirPermissaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
