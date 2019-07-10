using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class NomeCompleto : ValueObject<NomeCompleto>
    {
        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomeCompleto(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }

        public string ObterNomeCompleto()
        {
            return String.Format("{0} {1}", PrimeiroNome, Sobrenome);
        }

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