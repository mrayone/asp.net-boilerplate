using FluentValidation;
using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public abstract class BasePermissaoPerfil<T> : ICommand where T : BasePermissaoPerfil<T>
    {
        public Guid Id { get; protected set; }
        public Guid PerfilId { get; protected set; }
        public Guid PermissaoId { get; protected set; }
        public bool Ativa { get; protected set; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool isValid();
    }
}
