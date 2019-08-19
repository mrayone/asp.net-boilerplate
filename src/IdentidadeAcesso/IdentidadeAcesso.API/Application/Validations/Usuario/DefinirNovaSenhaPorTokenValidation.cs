using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class DefinirNovaSenhaPorTokenValidation : AbstractValidator<DefinirNovaSenhaPorTokenCommand>
    {
        public DefinirNovaSenhaPorTokenValidation()
        {
            RuleFor(d => d.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(d => d.Token).NotNull().NotEmpty();
            RuleFor(d => d.Senha)
                .Must(ValidarSenha)
                .WithMessage("A senha deve ter pelo menos uma minúscula.\n"+
                            "A senha deve ter pelo menos uma maiúscula.\n"+
                            "A senha deve ter pelo menos um número.\n"+
                            "A senha deve ter pelo menos um caractere especial.\n"+
                            "A senha deve no mínimo conter 8 caracteres.");
            RuleFor(d => d.ConfirmaSenha)
                .NotNull()
                .NotEmpty()
                .Equal(c => c.Senha).WithMessage("A confirmação de senha não é igual a senha fornecida.");
        }

        private bool ValidarSenha(string arg)
        {
            if (string.IsNullOrEmpty(arg)) return false;
            return Regex.IsMatch(arg, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$");
        }
    }
}
