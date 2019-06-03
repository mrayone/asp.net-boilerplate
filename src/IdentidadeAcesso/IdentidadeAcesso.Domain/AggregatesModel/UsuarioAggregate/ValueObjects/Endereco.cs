using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Endereco : ValueObject<Endereco>
    {

        private const int DigMaxCep = 8;
        private const string CepPattern = @"\d{8}";
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
            ValidarCEP();
        }

        private void ValidarCEP()
        {
            if (ObterCEPLimpo(CEP).Length != DigMaxCep)
            {
                ValidationResult.AdicionarErro("O CEP deve conter 8 dígitos.");
                return;
            }

            if (!Regex.IsMatch(CEP, CepPattern))
            {
                ValidationResult.AdicionarErro("O CEP é inválido.");
                return;
            }
        }

        private string ObterCEPLimpo(string cep)
        {
            return Regex.Replace(cep, CepPattern, "");
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