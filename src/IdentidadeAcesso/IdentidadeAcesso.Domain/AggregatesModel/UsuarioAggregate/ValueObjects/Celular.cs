using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Celular : ValueObject<Celular>
    {
        private const int MaxNumeros = 14;
        private const string Pattern = @"(\+\d{2})+(\d{11})";
        public string Numero { get; private set; }
        public Celular(string numero)
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
            if (Numero.Length > MaxNumeros)
            {
                ValidationResult.AddError("Celular","O celular não pode exceder 14 caracteres.");
                return;
            }

            if (!Regex.IsMatch(Numero, Pattern))
            {
                ValidationResult.AddError("Celular", "Celular com formato inválido.");
                return;
            }
        }

        protected override bool EqualsCore(Celular other)
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