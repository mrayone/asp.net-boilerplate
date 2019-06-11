using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands
{
    public abstract class Command
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool isValid();
    }
}
