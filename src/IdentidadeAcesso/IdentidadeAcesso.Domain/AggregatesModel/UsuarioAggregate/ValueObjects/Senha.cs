using IdentidadeAcesso.Domain.SeedOfWork;
using Microsoft.AspNet.Identity;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Senha : ValueObject<Senha>
    {

        public Senha(string caracteres)
        {
            Caracteres = new PasswordHasher().HashPassword(caracteres) ??  throw new ArgumentNullException("A Senha não pode ser nula.");
        }

        public string Caracteres { get; private set; }

        protected override bool EqualsCore(Senha other)
        {
            return this.Caracteres.Equals(other.Caracteres);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Caracteres.GetHashCode() * 907) ^ Caracteres.GetHashCode();
                return hash;
            }
        }
    }
}