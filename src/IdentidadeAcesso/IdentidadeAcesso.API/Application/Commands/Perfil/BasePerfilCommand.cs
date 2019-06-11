using FluentValidation;
using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Commands.Perfil
{
    public abstract class BasePerfilCommand<T> : ICommand where T: BasePerfilCommand<T>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Status { get; protected set; }

        public IList<PermissaoAssinadaDTO> PermissoesAssinadas { get; protected set; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool isValid();
    }

    public class PermissaoAssinadaDTO
    {
        public Guid PermissaoId { get; set; }
        public bool Status { get; set; }
    }
}