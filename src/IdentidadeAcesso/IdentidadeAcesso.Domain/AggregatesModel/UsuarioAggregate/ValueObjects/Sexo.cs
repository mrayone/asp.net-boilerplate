using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Sexo : ValueObject<Sexo>
    {
        public static Sexo Masculino = new Sexo("M");
        public static Sexo Feminino = new Sexo("F");
        public string Tipo { get; private set; }

        private Sexo(string tipo)
        {
            Tipo = tipo;
            Validar();
        }

        public Sexo()
        {
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Tipo))
            {
                ValidationResult.AdicionarErro("O sexo deve ser definido como 'Masculino' ou 'Feminino'.");
            }
        }

        protected override bool EqualsCore(Sexo other)
        {
            return Tipo.Equals(other.Tipo);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Tipo.GetHashCode() * 907) ^ Tipo.GetHashCode();

                return hash;
            }
        }
    }
}