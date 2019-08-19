using IdentidadeAcesso.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public class TokenRedefinicaoSenha : Entity
    {
        public string Token { get; private set; }
        public string Email { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public Guid UsuarioId { get; private set; }
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        protected TokenRedefinicaoSenha()
        {
            Id = new Guid();
            CriadoEm = DateTime.UtcNow;
        }

        public TokenRedefinicaoSenha(string email, Guid usuarioId) : this()
        {
            Email = email;
            UsuarioId = usuarioId;
            Token = GerarToken();
        }
        public string GerarToken()
        {
            return Encrypt();
        }

        public bool TokenValido()
        {
            byte[] data = Convert.FromBase64String(Token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            DateTime dataLimite = DateTime.UtcNow.AddHours(-24);
            if (when < dataLimite) { return false; }
            return true;
        }

        private string Encrypt()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        public class TokenRedefinicaoSenhaFactory
        {
            public static TokenRedefinicaoSenha CriarToken(string token, string email, Guid usuarioId)
            {
                return new TokenRedefinicaoSenha()
                {
                    Token = token,
                    Email = email,
                    UsuarioId = usuarioId,
                    CriadoEm = DateTime.UtcNow
                };
            }
        }
    }

}
