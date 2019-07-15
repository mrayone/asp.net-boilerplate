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
    public class CancelarPermissaoCommand : BasePermissaoPerfil<CancelarPermissaoCommand>
    {
        public CancelarPermissaoCommand(Guid perfilId, Guid permissaoId)
        {
            PerfilId = perfilId;
            PermissaoId = permissaoId;
        }
    }
}
