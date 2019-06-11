using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace IdentidadeAcesso.Domain.SeedOfWork.interfaces
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; set; }
        bool isValid();
    }
}
