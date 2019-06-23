using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>, IRequest<bool>
    {
        public CriarPerfilCommand(Guid id, string nome, string descricao, bool status,
            IList<PermissaoAssinadaDTO> permissoesAssinadas)
        {
            Id = id; //TODO: Remover este campo para o command criar.
            Nome = nome;
            Descricao = descricao;
            Status = status;
            PermissoesAssinadas = permissoesAssinadas;
        }

        public override bool isValid()
        {
            ValidationResult = new CriarPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
