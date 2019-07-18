using System;
using System.Text.RegularExpressions;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Celular : ValueObject<Celular>
    {
        private const int MaxNumeros = 14;
        private const string Pattern = @"(\+\d{2})+(\d{11})";
        public string NumeroCel { get; private set; }
        public Celular(string numeroCel)
        {
            NumeroCel = numeroCel;
        }

        protected override bool EqualsCore(Celular other)
        {
            return NumeroCel.Equals(other.NumeroCel);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (NumeroCel.GetHashCode() * 907) ^ NumeroCel.GetHashCode();

                return hash;
            }
        }
    }
}