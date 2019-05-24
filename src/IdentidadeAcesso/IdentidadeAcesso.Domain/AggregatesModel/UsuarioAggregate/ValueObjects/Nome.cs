using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Nome : ValueObject<Nome>
    {
        private readonly string _primeiroNome;
        private readonly string _sobrenome;

        public string PrimeiroNome
        {
            get
            {
                return _primeiroNome;
            }
        }

        public string Sobrenome
        {
            get
            {
                return _sobrenome;
            }
        }


        public Nome(string primeiroNome, string sobrenome)
        {
            _primeiroNome = primeiroNome;
            _sobrenome = sobrenome;
            
            Validar();
        }

        private void Validar()
        {
            if (_primeiroNome == null || _primeiroNome == String.Empty) ValidationResult.AdicionarErro("PrimeiroNome", "O primeiro nome não pode ser vazio.");
            if (_sobrenome == null || _sobrenome == String.Empty) ValidationResult.AdicionarErro("Sobrenome", "O sobrenome não pode ser vazio.");
        }

        public string ObterNomeCompleto()
        {
            return String.Format("{0} {1}", _primeiroNome, _sobrenome);
        }

        protected override bool EqualsCore(Nome other)
        {
            return _primeiroNome.Equals(other.PrimeiroNome)
                && _sobrenome.Equals(other.Sobrenome);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hash = _primeiroNome.GetHashCode();
                hash = (hash * 907) ^ _sobrenome.GetHashCode();

                return hash;
            }
        }
    }
}