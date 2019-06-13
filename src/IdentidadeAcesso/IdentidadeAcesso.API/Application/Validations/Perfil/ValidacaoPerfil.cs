using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Perfil
{
    public abstract class ValidacaoPerfil<T>: AbstractValidator<BasePerfilCommand<T>> where T : BasePerfilCommand<T>
    {
        public ValidacaoPerfil()
        {
            RuleFor(command => command.Nome)
                .NotEmpty()
                .WithMessage("Por favor forneça o nome do perfil.")
                .NotNull()
                .WithMessage("Por favor forneça o nome do perfil.")
                .Length(3, 50).WithMessage("O nome só pode conter entre 3 e 50 caracteres.");

            RuleFor(command => command.Descricao)
                .Length(3, 50).WithMessage("A descrição só pode conter entre 3 e 150 caracteres.");

            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
