using FluentValidation;
using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public abstract class BasePerfilCommand<T> : IRequest<CommandResponse> where T: BasePerfilCommand<T>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Status { get; protected set; }

    }

    public class PermissaoAssinadaDTO
    {
        [Required]
        public Guid PermissaoId { get; set; }

        [Required]
        public Guid PerfilId { get; set; }
        public bool Status { get; set; }
    }
}