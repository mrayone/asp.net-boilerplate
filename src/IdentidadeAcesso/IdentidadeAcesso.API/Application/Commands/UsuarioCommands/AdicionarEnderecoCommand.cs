using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class AdicionarEnderecoCommand : ICommand
    {
        public ValidationResult ValidationResult { get; set; }

        public bool isValid()
        {
            return false;
        }
    }
}
