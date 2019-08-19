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
            var s = Token;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    s += "==";
                    break; // Two pad chars
                case 3:
                    s += "=";
                    break; // One pad char
                default:
                    throw new Exception("Illegal base64 url string!");
            }

            byte[] data = Convert.FromBase64String(s);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            DateTime dataLimite = DateTime.UtcNow.AddHours(-24);
            if (when < dataLimite) { return false; }
            return true;
        }

        private string Encrypt()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            var token =  Convert.ToBase64String(time.Concat(key).ToArray());
            token = token.Split('=')[0]; // Remove any trailing '='s
            token = token.Replace('+', '-'); // 62nd char of encoding
            token = token.Replace('/', '_'); // 63rd char of encoding
            return token;
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
