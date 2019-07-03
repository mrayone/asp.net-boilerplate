using FluentValidation.Results;
using IdentidadeAcesso.API.Application.Validations.Usuario;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class ExcluirUsuarioCommand : IRequest<bool>, ICommand
    {
        public ValidationResult ValidationResult { get; protected set; }
        public Guid Id { get; private set; }

        public ExcluirUsuarioCommand(Guid id)
        {
            Id = id;
        }

        public bool isValid()
        {
            ValidationResult = new ExcluirUsuarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
