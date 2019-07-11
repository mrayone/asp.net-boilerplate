using FluentValidation.Results;
using IdentidadeAcesso.API.Application.Validations.Perfil;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class CancelarPermissaoPerfilCommand : ICommand, IRequest<bool>
    {
        public CancelarPermissaoPerfilCommand(Guid perfilId, Guid permissaoId)
        {
            PerfilId = perfilId;
            PermissaoId = permissaoId;
        }

        public ValidationResult ValidationResult { get ; set ; }
        public Guid PerfilId { get; }
        public Guid PermissaoId { get; }

        public bool isValid()
        {
            ValidationResult = new CancelarPermissoesValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
