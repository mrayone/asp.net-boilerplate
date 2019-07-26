using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class NovoUsuarioValidation : ValidacaoUsuario<NovoUsuarioCommand>
    {
        public NovoUsuarioValidation() : base()
        {
            RuleFor(c => c.Senha).NotNull()
                        .Must(SenhaPattern).WithMessage("A senha deve ter no mínimo 6 caracteres, no máximo 10 caracteres, " +
                        "e deve incluir pelo menos uma letra maiúscula, uma letra minúscula e um dígito numérico.")
                        .MinimumLength(6)
                        .MaximumLength(10);

            RuleFor(c => c.ConfirmacaoSenha).Equal(c => c.Senha)
                .WithMessage("A confirmação de senha não é igual a senha fornecida.");
        }


        private bool SenhaPattern(string arg)
        {
            return Regex.IsMatch(arg, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10}$");
        }

    }
}
