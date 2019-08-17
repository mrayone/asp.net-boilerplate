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
            return Encrypt(string.Format("{0}#{1}", Email, CriadoEm));
        }

        public bool TokenValido()
        {
            var stringData = Decrypt(Token).Split('#')[1];
            DateTime when = Convert.ToDateTime(stringData);
            DateTime dataLimite = DateTime.UtcNow.AddHours(-24);
            if (when < dataLimite) { return false; }
            return true;
        }

        private string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        private string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
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
