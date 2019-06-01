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
            if (string.IsNullOrEmpty(Estado))
            {
                ValidationResult.AdicionarErro("Estado Nulo/Vazio", "O estado deve ser fornecido.");
                return;
            }
        }

        private void ValidarCidade()
        {
            if (string.IsNullOrEmpty(Cidade))
            {
                ValidationResult.AdicionarErro("Cidade Nulo/Vazio", "A cidade deve ser fornecida.");
                return;
            }
        }

        private void ValidarCEP()
        {
            if (string.IsNullOrEmpty(CEP))
            {
                ValidationResult.AdicionarErro("CEP Nulo/Vazio", "O cep deve ser fornecido.");
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
            if (string.IsNullOrEmpty(Bairro))
            {
                ValidationResult.AdicionarErro("Bairro Nulo/Vazio", "O bairro deve ser fornecido.");
                return;
            }
        }

        private void ValidarNumero()
        {
            if (string.IsNullOrEmpty(Numero))
            {
                ValidationResult.AdicionarErro("Numero Nulo/Vazio", "O numero deve ser fornecido.");
                return;
            }
        }

        private void ValidarLogradouro()
        {
            if (string.IsNullOrEmpty(Logradouro))
            {
                ValidationResult.AdicionarErro("Logradouro Nulo/Vazio", "O logradouro deve ser fornecido.");
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