using FluentValidation;
using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands
{
    public abstract class Command : ICommand
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool isValid();
    }
}
