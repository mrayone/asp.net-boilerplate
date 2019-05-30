using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Endereco : ValueObject<Endereco>
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public Endereco(string logradouro, string numero, 
            string bairro, string cep, string cidade, string estado, string complemento = "")
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;

            Validar();
        }

        private void Validar()
        {
            ValidarLogradouro();
            ValidarNumero();
            ValidarComplemento();
            ValidarBairro();
            ValidarCEP();
            ValidarCidade();
            ValidarEstado();
        }

        private void ValidarEstado()
        {
            if (Estado == null)
            {
                ValidationResult.AdicionarErro("Estado Nulo", "O estado não pode ser nulo.");
                return;
            }

            if (Estado == String.Empty)
            {
                ValidationResult.AdicionarErro("Estado Vazio", "O estado não pode ser vazio.");
                return;
            }
        }

        private void ValidarCidade()
        {
            if (Cidade == null)
            {
                ValidationResult.AdicionarErro("Cidade Nula", "A cidade não pode ser nulo.");
                return;
            }

            if (Cidade == String.Empty)
            {
                ValidationResult.AdicionarErro("Cidade Vazio", "A cidade não pode ser vazia.");
                return;
            }
        }

        private void ValidarCEP()
        {
            if (CEP == null)
            {
                ValidationResult.AdicionarErro("CEP Nulo", "O cep não pode ser nulo.");
                return;
            }

            if (CEP == String.Empty)
            {
                ValidationResult.AdicionarErro("CEP Vazio", "O cep não pode ser vazio.");
                return;
            }
        }

        private void ValidarComplemento()
        {
            if (Complemento == null)
            {
                ValidationResult.AdicionarErro("Complemento Nulo", "O complemento não pode ser nulo.");
                return;
            }
        }

        private void ValidarBairro()
        {
            if (Bairro == null)
            {
                ValidationResult.AdicionarErro("Bairro Nulo", "O bairro não pode ser nulo.");
                return;
            }

            if (Bairro == String.Empty)
            {
                ValidationResult.AdicionarErro("Bairro Vazio", "O bairro não pode ser vazio.");
                return;
            }
        }

        private void ValidarNumero()
        {
            if (Numero == null)
            {
                ValidationResult.AdicionarErro("Numero Nulo", "O numero não pode ser nulo.");
                return;
            }

            if (Numero == String.Empty)
            {
                ValidationResult.AdicionarErro("Numero Vazio", "O numero não pode ser vazio.");
                return;
            }
        }

        private void ValidarLogradouro()
        {
            if (Logradouro == null)
            {
                ValidationResult.AdicionarErro("Logradouro Nulo", "O logradouro não pode ser nulo.");
                return;
            }

            if (Logradouro == String.Empty)
            {
                ValidationResult.AdicionarErro("Logradouro Vazio", "O logradouro não pode ser vazio.");
                return;
            }
        }

        protected override bool EqualsCore(Endereco other)
        {
            return Logradouro.Equals(other.Logradouro)
                && Numero.Equals(other.Numero)
                && Complemento.Equals(other.Complemento)
                && Bairro.Equals(other.Bairro)
                && CEP.Equals(other.CEP)
                && Cidade.Equals(other.Cidade)
                && Estado.Equals(other.Estado);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = Logradouro.GetHashCode();
                hash += (Numero.GetHashCode() * 907) ^ Numero.GetHashCode();
                hash += (Complemento.GetHashCode() * 907) ^ Complemento.GetHashCode();
                hash += (Bairro.GetHashCode() * 907) ^ Bairro.GetHashCode();
                hash += (CEP.GetHashCode() * 907) ^ CEP.GetHashCode();
                hash += (Cidade.GetHashCode() * 907) ^ Cidade.GetHashCode();
                hash += (Estado.GetHashCode() * 907) ^ Estado.GetHashCode();

                return hash;
            }
        }
    }
}