using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Nome : ValueObject<Nome>
    {
        public readonly string PrimeiroNome;

        public readonly string Sobrenome;

        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            Validar();
        }

        private void Validar()
        {
            ValidarNome();
            ValidarSobrenome();
        }

        public string ObterNomeCompleto()
        {
            return String.Format("{0} {1}", PrimeiroNome, Sobrenome);
        }

        #region Validações
        private void ValidarNome()
        {
            if (PrimeiroNome == null)
            {
                ValidationResult.AdicionarErro("Primeiro Nome Nulo", "O primeiro nome não pode ser nulo.");
                return;
            }
            if (PrimeiroNome == String.Empty)
            {
                ValidationResult.AdicionarErro("Primeiro Nome Vazio", "O primeiro nome não pode ser vazio.");
                return;
            }
        }

        private void ValidarSobrenome()
        {
            if (Sobrenome == null)
            {
                ValidationResult.AdicionarErro("Sobrenome Nulo", "O sobrenome não pode ser nulo.");
                return;
            }
            if (Sobrenome == String.Empty)
            {
                ValidationResult.AdicionarErro("Sobrenome Vazio", "O sobrenome não pode ser vazio.");
                return;
            }
        }
        #endregion


        protected override bool EqualsCore(Nome other)
        {
            return PrimeiroNome.Equals(other.PrimeiroNome)
                && Sobrenome.Equals(other.Sobrenome);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hash = PrimeiroNome.GetHashCode();
                hash = (hash * 907) ^ Sobrenome.GetHashCode();

                return hash;
            }
        }
    }
}