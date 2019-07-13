using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public abstract class BasePermissaoPerfil<T> : ICommand, IRequest<bool> where T : BasePermissaoPerfil<T>
    {
        public ValidationResult ValidationResult { get; protected set; }
        public Guid PerfilId { get; protected set; }
        public Guid PermissaoId { get; protected set; }

        public abstract bool isValid();
    }
}
