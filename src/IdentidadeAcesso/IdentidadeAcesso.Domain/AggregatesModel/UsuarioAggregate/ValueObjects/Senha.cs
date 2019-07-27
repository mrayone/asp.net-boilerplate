using IdentidadeAcesso.Domain.SeedOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using PasswordVerificationResult = Microsoft.AspNet.Identity.PasswordVerificationResult;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Senha : ValueObject<Senha>
    {
        private readonly PasswordHasher hasher;
        public string Caracteres { get; private set; }
        protected Senha(string caracteres) : this ()
        {
            Caracteres = caracteres ?? throw new ArgumentNullException("A Senha não pode ser nula.");
        }

        public Senha()
        {
            hasher = new PasswordHasher();
        }

        public static Senha GerarSenha(string senha)
        {
            var hasher = new PasswordHasher();
            return new Senha(hasher.HashPassword(senha));
        }

        public bool ValidarSenha(string senha)
        {
            var senhaHash = hasher.VerifyHashedPassword(Caracteres, senha);
            return senhaHash == PasswordVerificationResult.Success;
        }

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