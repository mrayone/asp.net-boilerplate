using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public abstract class BasePermissaoPerfil<T> : IRequest<CommandResponse> where T : BasePermissaoPerfil<T>
    {
        [DataMember]
        public Guid PerfilId { get; protected set; }

        [DataMember]
        public IList<AtribuicaoDTO> Atribuicoes { get; protected set; }

    }
}
