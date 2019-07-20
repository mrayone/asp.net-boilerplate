using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Sexo : ValueObject<Sexo>
    {
        public static Sexo Masculino = new Sexo(nameof(Masculino));
        public static Sexo Feminino = new Sexo(nameof(Feminino));
        public string Tipo { get; private set; }

        private Sexo(string tipo)
        {
            Tipo = tipo;
        }

        protected override bool EqualsCore(Sexo other)
        {
            return Tipo.Equals(other.Tipo);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Tipo.GetHashCode() * 907) ^ GetHashCode();

                return hash;
            }
        }
    }
}