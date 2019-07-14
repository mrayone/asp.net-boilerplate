using FluentValidation.Results;
using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public abstract class BasePermissaoCommand<T> : IRequest<Response> where T : BasePermissaoCommand<T>
    {
        public string Tipo { get; protected set; }
        public string Valor { get; protected set; }
        public Guid Id { get; protected set; }
    }
}
