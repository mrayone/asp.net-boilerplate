using FluentValidation.Results;
using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public abstract class BasePermissaoCommand<T> : IRequest<CommandResponse> where T : BasePermissaoCommand<T>
    {
        [DataMember]
        public string Tipo { get; protected set; }
        [DataMember]
        public string Valor { get; protected set; }
        [DataMember]
        public Guid Id { get; protected set; }
    }
}
