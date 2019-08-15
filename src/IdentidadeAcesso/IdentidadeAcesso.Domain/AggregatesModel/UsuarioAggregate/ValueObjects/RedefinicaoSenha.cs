using IdentidadeAcesso.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class RedefinicaoSenha : ValueObject<RedefinicaoSenha>
    {
        public string Token { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string Email { get; private set; }

        protected RedefinicaoSenha(string token, string email, DateTime criadoEm)
        {
            Token = token;
            CriadoEm = criadoEm;
            Email = email;
        }

        public static RedefinicaoSenha GerarRedefinicaoDeSenha(string email)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return new RedefinicaoSenha(token, email, DateTime.UtcNow);
        }

        public static bool TokenValido(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            DateTime dataLimite = DateTime.UtcNow.AddHours(-24);
            if (when < dataLimite) { return false; }
            return true;
        }

        protected override bool EqualsCore(RedefinicaoSenha other)
        {
            return Token.Equals(other.Token) 
                && Email.Equals(other.Email) 
                && CriadoEm.Equals(other.CriadoEm);
        }

        protected override int GetHashCodeCore()
        {
           unchecked
            {
                var hash = Token.GetHashCode();
                hash += (CriadoEm.GetHashCode() * 907) ^ CriadoEm.GetHashCode();
                hash += (Email.GetHashCode() * 907) ^ Email.GetHashCode();

                return hash;
            }
        }
    }
}
