using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Perfil
{
    public class CancelarPermissoesValidation : AbstractValidator<CancelarPermissoesPerfilCommand>
    {
        public CancelarPermissoesValidation()
        {
            RuleFor(c => c.PerfilId).NotEqual(Guid.Empty).WithMessage("É necessário informar o ID do perfil.");
            RuleFor(c => c.PermissoesAssinadas).NotEmpty().WithMessage("As permissões assinadas deve ser informado.");
        }
    }
}
