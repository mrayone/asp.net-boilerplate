using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Perfil
{
    public class AssinarPermissaoPerfilCommandValidation : AbstractValidator<AssinarPermissaoPerfilCommand>
    {
        public AssinarPermissaoPerfilCommandValidation()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.PerfilId).NotEqual(Guid.Empty);
            RuleFor(command => command.PermissaoId).NotEqual(Guid.Empty);
            RuleFor(command => command.Ativa).NotEqual(false);
        }
    }
}
