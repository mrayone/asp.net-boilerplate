using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace IdentidadeAcesso.Domain.SeedOfWork.Interfaces
{
    public interface ICommand
    {
        bool isValid();
    }
}
