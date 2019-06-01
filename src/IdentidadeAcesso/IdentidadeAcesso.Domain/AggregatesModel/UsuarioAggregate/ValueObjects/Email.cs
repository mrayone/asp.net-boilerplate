using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Email : ValueObject<Email>
    {

        private const string Pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public readonly string Endereco;

        public Email(string endereco)
        {
            Endereco = endereco;

            Validar();
        }

        private void Validar()
        {
            ValidaraEndereco();
        }

        private void ValidaraEndereco()
        {
            if (string.IsNullOrEmpty(Endereco))
            {
                ValidationResult.AdicionarErro("Email Nulo/Vazio", "O email deve ser fornecido.");
                return;
            }

            if (!Regex.IsMatch(Endereco, Pattern))
            {
                ValidationResult.AdicionarErro("Email Inválido", "O email informado não é um válido.");
            }
        }

        protected override bool EqualsCore(Email other)
        {
            return Endereco.Equals(other.Endereco);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hash = (Endereco.GetHashCode() * 907) ^ Endereco.GetHashCode();

                return hash;
            }
        }
    }
}