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
    public class CancelarPermissoesPerfilCommand : ICommand, IRequest<bool>
    {
        public CancelarPermissoesPerfilCommand(Guid perfilId, IList<PermissaoAssinadaDTO> permissoesAssinadas)
        {
            PerfilId = perfilId;
            PermissoesAssinadas = permissoesAssinadas;
        }

        public Guid PerfilId { get; private set; }
        public IList<PermissaoAssinadaDTO> PermissoesAssinadas { get; private set; }
        public ValidationResult ValidationResult { get ; set ; }

        public bool isValid()
        {
            ValidationResult = new CancelarPermissoesValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
