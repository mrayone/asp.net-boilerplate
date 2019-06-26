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
        public string Cep { get; private set; }
        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public Endereco(string logradouro, string numero, 
            string bairro, string cep, string cidade, string estado, string complemento = "")
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
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
            if (ObterCEPLimpo(Cep).Length != DigMaxCep)
            {
                ValidationResult.AddError("CEP","O CEP deve conter 8 dígitos.");
                return;
            }

            if (!Regex.IsMatch(Cep, CepPattern))
            {
                ValidationResult.AddError("CEP","O CEP é inválido.");
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
                && Cep.Equals(other.Cep)
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
                hash += (Cep.GetHashCode() * 907) ^ Cep.GetHashCode();
                hash += (Cidade.GetHashCode() * 907) ^ Cidade.GetHashCode();
                hash += (Estado.GetHashCode() * 907) ^ Estado.GetHashCode();

                return hash;
            }
        }
    }
}