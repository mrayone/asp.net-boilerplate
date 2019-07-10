using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;
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