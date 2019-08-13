using FluentValidation;
using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public abstract class BasePerfilCommand<T> : IRequest<CommandResponse> where T: BasePerfilCommand<T>
    {
        [DataMember]
        public Guid Id { get; protected set; }
        [DataMember]
        public string Nome { get; protected set; }
        [DataMember]
        public string Descricao { get; protected set; }

        public List<AtribuicaoDTO> Atribuicoes { get; protected set; }

    }
}