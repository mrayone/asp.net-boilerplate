using IdentidadeAcesso.API.Application.Validations.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AssinarPermissaoPerfilCommand : BasePermissaoPerfil<AssinarPermissaoPerfilCommand>
    {
        public AssinarPermissaoPerfilCommand(Guid perfilId, Guid permissaoId)
        {
            PerfilId = perfilId;
            PermissaoId = permissaoId;
        }

        public override bool isValid()
        {
            ValidationResult = new AssinarPermissaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
