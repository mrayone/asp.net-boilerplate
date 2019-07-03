using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public abstract class ValidacaoUsuario<T> : AbstractValidator<T> where T : BaseUsuarioCommand<T>
    {
        public ValidacaoUsuario()
        {
            RuleFor(c => c.Nome).NotNull()
                 .NotEmpty()
                 .MaximumLength(150)
                 .MinimumLength(3);

            RuleFor(c => c.Sobrenome).NotNull()
                 .NotEmpty()
                 .MaximumLength(150)
                 .MinimumLength(3);

            RuleFor(c => c.CPF).NotNull()
                 .NotEmpty()
                 .MaximumLength(14)
                 .MinimumLength(11);

            RuleFor(c => c.DateDeNascimento)
                .NotEmpty()
                .Must(IdadeMinima)
                .WithMessage("O usuário deve ter 16 anos ou mais.");

            RuleFor(c => c.Sexo)
                .Must(v => !v.Equals("M") || !v.Equals("F"))
                .WithMessage("O sexo deve ser definido como 'M' masculino ou 'F' feminino.");

            RuleFor(c => c.Email).NotNull()
                .NotEmpty().EmailAddress();

            RuleFor(c => c.Celular).Length(11, 14)
                .NotEmpty().NotNull();

            RuleFor(c => c.Telefone).Length(11, 14);

            RuleFor(c => c.Logradouro)
                .Length(2, 150).WithMessage("O logradouro deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.Numero)
               .Length(2, 10).WithMessage("O logradouro deve conter entre 2 e 10 caracteres");

            RuleFor(c => c.Cidade)
               .Length(2, 150).WithMessage("A cidade deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.CEP)
               .Length(8).WithMessage("O CEP deve conter exatamente 8 caracteres");

            RuleFor(c => c.Estado)
               .Length(2, 150).WithMessage("O estado deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.Bairro)
               .Length(2, 150).WithMessage("O bairro deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.Complemento)
               .Length(2, 150).WithMessage("O bairro deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.PerfilId)
                .NotEqual(Guid.Empty)
                .WithMessage("O ID do perfil tem que ser fornecido.");
        }

        private bool IdadeMinima(DateTime arg)
        {
            return arg <= DateTime.Now.AddYears(-16);
        }
    }
}
