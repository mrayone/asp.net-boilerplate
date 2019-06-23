using IdentidadeAcesso.API.Application.Validations.Permissao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public class CriarPermissaoCommand : BasePermissaoCommand<CriarPermissaoCommand>, IRequest<bool>
    {
        public CriarPermissaoCommand(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
        public override bool isValid()
        {
            ValidationResult = new CriarPermissaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
