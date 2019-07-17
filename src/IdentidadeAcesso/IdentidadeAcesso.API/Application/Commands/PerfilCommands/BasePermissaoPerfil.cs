using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public abstract class BasePermissaoPerfil<T> : IRequest<CommandResponse> where T : BasePermissaoPerfil<T>
    {
        public Guid PerfilId { get; protected set; }
        public IList<AssinaturaDTO> Assinaturas { get; protected set; }

    }
}
