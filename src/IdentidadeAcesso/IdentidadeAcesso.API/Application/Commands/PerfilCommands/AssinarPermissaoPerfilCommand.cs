using FluentValidation;
using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AssinarPermissaoPerfilCommand : BasePermissaoPerfil<AssinarPermissaoPerfilCommand>, IRequest<bool>
    {
        public AssinarPermissaoPerfilCommand(Guid id, Guid perfilId, Guid permissaoId, bool ativa = true) 
        {
            Id = id;
            PerfilId = perfilId;
            PermissaoId = permissaoId;
            Ativa = ativa;
        }

        public override bool isValid()
        {
            ValidationResult = new AssinarPermissaoPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
