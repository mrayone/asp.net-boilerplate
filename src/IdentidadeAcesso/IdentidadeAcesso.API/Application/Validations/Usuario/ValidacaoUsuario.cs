using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                 .Must(CPFValido).WithMessage("O CPF informado é inválido.")
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

            RuleFor(c => c.Celular)
                .Must(n => !Regex.IsMatch(n, @"(\+\d{2})+(\d{11})"))
                .WithMessage("O celular deve obedecer o padrão Ex: +5518999928663")
                .Length(11, 15)
                .NotEmpty().NotNull();

            RuleFor(c => c.Telefone)
                .Must(n => !Regex.IsMatch(n, @"(\+\d{2})+(\d{10})"))
                .WithMessage("O telefone deve obedecer o padrão Ex: +551832815555")
                .Length(11, 13);

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

        private bool CPFValido(string arg)
        {
            var MaxDigitos = 11;
            var cpf = CPF.LimparFormatacaoCPF(arg);

            if (cpf.Length > MaxDigitos)
                return false;

            while (cpf.Length != MaxDigitos)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < MaxDigitos; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != MaxDigitos - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % MaxDigitos;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != MaxDigitos - resultado)
                return false;

            return true;
        }

        private bool IdadeMinima(DateTime arg)
        {
            return arg <= DateTime.Now.AddYears(-16);
        }
    }
}
