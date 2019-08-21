using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class NumerosContato : ValueObject<NumerosContato>
    {
        public string NumeroCel { get; private set; }
        public string NumeroTelefone { get; private set; }

        public NumerosContato(string numeroCel, string numeroTelefone)
        {
            NumeroCel = numeroCel;
            NumeroTelefone = numeroTelefone;
        }

        protected override bool EqualsCore(NumerosContato other)
        {
            return NumeroCel.Equals(other.NumeroCel) && NumeroTelefone.Equals(other.NumeroTelefone);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (NumeroCel.GetHashCode() * 907) ^ NumeroCel.GetHashCode();
                hash += (NumeroTelefone.GetHashCode() * 907) ^ NumeroTelefone.GetHashCode();

                return hash;
            }
        }
    }
}