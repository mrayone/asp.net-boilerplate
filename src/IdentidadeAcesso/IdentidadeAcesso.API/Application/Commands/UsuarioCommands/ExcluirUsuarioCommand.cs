using FluentValidation.Results;
using IdentidadeAcesso.API.Application.Validations.Usuario;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class ExcluirUsuarioCommand : IRequest<CommandResponse>
    {
        public Guid Id { get; private set; }

        public ExcluirUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }
}
