using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class RegistrarUsuarioValidation : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioValidation()
        {
            RuleFor(c => c.Senha).NotNull()
                        .Must(SenhaPattern).WithMessage("A senha deve ter no mínimo 6 caracteres, no máximo 10 caracteres, " +
                        "e deve incluir pelo menos uma letra maiúscula, uma letra minúscula e um dígito numérico.")
                        .MinimumLength(6)
                        .MaximumLength(10);

            RuleFor(c => c.ConfirmacaoSenha).Equal(c => c.Senha)
                .WithMessage("A confirmação de senha não é igual a senha fornecida.");

            RuleFor(c => c.Nome).NotNull()
             .NotEmpty()
             .MaximumLength(150)
             .MinimumLength(3);

            RuleFor(c => c.Sobrenome).NotNull()
                 .NotEmpty()
                 .MaximumLength(150)
                 .MinimumLength(3);

            RuleFor(c => c.DataDeNascimento)
            .NotEmpty()
            .Must(IdadeMinima)
            .WithMessage("O usuário deve ter 16 anos ou mais.");

            RuleFor(c => c.Email).NotNull()
            .NotEmpty().EmailAddress();

            RuleFor(c => c.Sexo)
            .Must(v => v.Equals("M") || v.Equals("F"))
            .WithMessage("O sexo deve ser definido como 'M' masculino ou 'F' feminino.");
        }

        private bool IdadeMinima(DateTime arg)
        {
            return arg <= DateTime.Now.AddYears(-16);
        }

        private bool SenhaPattern(string arg)
        {
            return Regex.IsMatch(arg, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10}$");
        }
    }
}
