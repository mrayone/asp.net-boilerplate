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
                 .NotEmpty()
                 .MaximumLength(14)
                 .MinimumLength(11)
                 .Must(MetodosDeValidacao.CPFValido).WithMessage("O CPF informado é inválido.");

            RuleFor(c => c.DataDeNascimento)
                .NotEmpty()
                .Must(MetodosDeValidacao.IdadeMinima)
                .WithMessage("O usuário deve ter 16 anos ou mais.");

            RuleFor(c => c.Sexo)
                .Must(v => v.Equals("M") || v.Equals("F"))
                .WithMessage("O sexo deve ser definido como 'M' masculino ou 'F' feminino.");

            RuleFor(c => c.Email).NotNull()
                .NotEmpty().EmailAddress();

            RuleFor(c => c.Celular)
                .Must(ValidarCelular)
                .WithMessage("O celular deve obedecer o padrão Ex: +5518999928663")
                .Length(11, 15);

            RuleFor(c => c.Telefone)
                .Must(ValidarTelefone)
                .WithMessage("O telefone deve obedecer o padrão Ex: +551832815555")
                .Length(11, 13);

            RuleFor(c => c.Logradouro)
                .Length(2, 150).WithMessage("O logradouro deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.Numero)
               .Length(2, 10).WithMessage("O logradouro deve conter entre 2 e 10 caracteres");

            RuleFor(c => c.Cidade)
               .Length(2, 150).WithMessage("A cidade deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.CEP)
                .Must(ValidarCEP).WithMessage("O CEP informado é inválido")
               .Length(8).WithMessage("O CEP deve conter exatamente 8 caracteres");

            RuleFor(c => c.Estado)
               .Length(2, 150).WithMessage("O estado deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.Bairro)
               .Length(2, 150).WithMessage("O bairro deve conter entre 2 e 150 caracteres");

            RuleFor(c => c.Complemento)
               .Length(2, 150).WithMessage("O bairro deve conter entre 2 e 150 caracteres");
        }

        private bool ValidarCEP(string arg)
        {
            if (!string.IsNullOrEmpty(arg))
                return Regex.IsMatch(arg, @"\d{8}");
            return true;
        }

        private bool ValidarTelefone(string arg)
        {
            if (arg != null)
                return Regex.IsMatch(arg, @"(\d{10})");

            return true;
        }

        private bool ValidarCelular(string arg)
        {
            if (arg != null)
                return Regex.IsMatch(arg, @"(\d{11})");

            return true;
        }
    }

    public static class MetodosDeValidacao
    {
        public static bool IdadeMinima(DateTime arg)
        {
            return arg <= DateTime.Now.AddYears(-16);
        }

        public static bool CPFValido(string arg)
        {
            if (string.IsNullOrEmpty(arg)) return false;
            if (!CPF.ValidarCPFPatterns(arg)) return false;

            var MaxDigitos = 11;
            var cpf = CPF.ObterCPFLimpo(arg).Digitos;

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
    }
}
