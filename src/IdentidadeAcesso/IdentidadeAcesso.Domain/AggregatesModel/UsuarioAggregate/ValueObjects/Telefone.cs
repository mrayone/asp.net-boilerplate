using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Telefone : ValueObject<Telefone>
    {
        private const int MaxNumeros = 13;
        private const string Pattern = @"(\+\d{2})+(\d{10})";
        public string Numero { get; private set; }
        public Telefone(string numero)
        {
            Numero = numero;
            Validar();
        }

        private void Validar()
        {
            ValidarNumero();
        }

        private void ValidarNumero()
        {
            if (string.IsNullOrEmpty(Numero))
            {
                ValidationResult.AdicionarErro("Telefone Vazio/Nulo", "O telefone precisa ser fornecido.");
                return;
            }

            if (Numero.Length > MaxNumeros)
            {
                ValidationResult.AdicionarErro("Telefone Tamanho Inválido", "O telefone não pode exceder 13 caracteres.");
                return;
            }

            if (!Regex.IsMatch(Numero, Pattern ))
            {
                ValidationResult.AdicionarErro("Telefone Inválido", "Telefone com formato inválido.");
                return;
            }
        }

        protected override bool EqualsCore(Telefone other)
        {
            return Numero.Equals(other.Numero);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Numero.GetHashCode() * 907) ^ Numero.GetHashCode();

                return hash;
            }
        }
    }
}