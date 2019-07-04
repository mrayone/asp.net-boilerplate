using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public abstract class BasePermissaoCommand<T> : ICommand where T : BasePermissaoCommand<T>
    {
        public string Tipo { get; protected set; }
        public string Valor { get; protected set; }
        public Guid Id { get; protected set; }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool isValid();
    }
}
