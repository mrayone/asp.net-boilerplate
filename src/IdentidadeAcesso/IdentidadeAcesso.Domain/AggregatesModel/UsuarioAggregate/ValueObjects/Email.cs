using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Email : ValueObject<Email>
    {

        private const string Pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public string Endereco { get; private set; }

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

            if (!Regex.IsMatch(Endereco, Pattern))
            {
                ValidationResult.AddError("Email","O email informado não é um válido.");
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