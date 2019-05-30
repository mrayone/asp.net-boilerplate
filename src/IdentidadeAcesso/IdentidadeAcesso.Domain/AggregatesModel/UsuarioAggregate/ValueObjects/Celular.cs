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
            if (Numero == null)
            {
                ValidationResult.AdicionarErro("Celular Nulo", "O celular não pode ser nulo.");
                return;
            }

            if (Numero == String.Empty)
            {
                ValidationResult.AdicionarErro("Celular Vazio", "O celular não pode ser vazio.");
                return;
            }

            if (Numero.Length > MaxNumeros)
            {
                ValidationResult.AdicionarErro("Celular de Tamanho Inválido", "O celular não pode exceder 14 caracteres.");
                return;
            }

            if (!Regex.IsMatch(Numero, Pattern))
            {
                ValidationResult.AdicionarErro("Celular Inválido", "Celular com formato inválido.");
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