using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class NomeCompleto : ValueObject<NomeCompleto>
    {
        public readonly string PrimeiroNome;

        public readonly string Sobrenome;

        public NomeCompleto(string primeiroNome, string sobrenome)
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
            if (string.IsNullOrEmpty(PrimeiroNome))
            {
                ValidationResult.AdicionarErro("Primeiro Nome Nulo/Vazio", "O primeiro nome deve ser fornecido.");
                return;
            }
        }

        private void ValidarSobrenome()
        {
            if (string.IsNullOrEmpty(Sobrenome))
            {
                ValidationResult.AdicionarErro("Sobrenome Nulo/Vazio", "O sobrenome deve ser fornecido.");
                return;
            }
        }
        #endregion


        protected override bool EqualsCore(NomeCompleto other)
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