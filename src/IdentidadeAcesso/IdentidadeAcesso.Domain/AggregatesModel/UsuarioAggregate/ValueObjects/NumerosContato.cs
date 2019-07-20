using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    //TODO: Refatorar Classe para obter telefone e celular, sendo obrigatório apenas o celular.
    public class NumerosContato : ValueObject<NumerosContato>
    {
        private const int MaxCelNumeros = 14;
        private const int MaxTelefone = 13;
        private const string Pattern = @"(\+\d{2})+(\d{11})";
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