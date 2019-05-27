using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Telefone : ValueObject<Telefone>
    {
        private const int MaxNumeros = 13;
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
            if(Numero == null)
            {
                ValidationResult.AdicionarErro("Número Nulo", "O número não pode ser nulo.");
                return;
            }

            if(Numero == String.Empty)
            {
                ValidationResult.AdicionarErro("Número Vazio", "O número não pode ser vazio.");
                return;
            }

            if (Numero.Length > MaxNumeros)
            {
                ValidationResult.AdicionarErro("Número Tamanho Inválido", "O número não pode ser exceder 13 caracteres.");
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