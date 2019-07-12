using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Perfil
{
    public class ValidacaoPermissaoPerfil<T> : AbstractValidator<T> where T : BasePermissaoPerfil<T>
    {
        public ValidacaoPermissaoPerfil()
        {
            RuleFor(c => c.PerfilId).NotEqual(Guid.Empty).WithMessage("É necessário informar o ID do perfil.");
            RuleFor(c => c.PermissaoId).NotEqual(Guid.Empty).WithMessage("É necessário fornecer o ID da permissão.");
        }
    }
}
