using IdentidadeAcesso.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public class TokenRedefinicaoSenha : Entity
    {
        public string Token { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        protected TokenRedefinicaoSenha()
        {
            Id = new Guid();
            Token = GerarRedefinicaoDeSenha();
            CriadoEm = DateTime.UtcNow;
        }

        public TokenRedefinicaoSenha(string token, DateTime criadoEm): this()
        {
            Token = token;
            CriadoEm = criadoEm;
        }
        private string GerarRedefinicaoDeSenha()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        public bool TokenValido()
        {
            byte[] data = Convert.FromBase64String(Token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            DateTime dataLimite = DateTime.UtcNow.AddHours(-24);
            if (when < dataLimite) { return false; }
            return true;
        }
    }
}
