using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>, IRequest<bool>
    {
        public CriarPerfilCommand(string nome, string descricao, bool status)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }

        public override bool isValid()
        {
            ValidationResult = new CriarPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
