using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects
{
    public class Atribuicao : ValueObject<Atribuicao>
    {
        public string Valor { get; private set; }

        public Atribuicao(string valor)
        {
            Valor = valor;

            Validar();
        }

        private void Validar()
        {
            ValidarValor();
        }

        private void ValidarValor()
        {
            if (string.IsNullOrEmpty(Valor))
            {
                ValidationResult.AdicionarErro("","");
            }
        }

        protected override bool EqualsCore(Atribuicao other)
        {
            return Valor.Equals(other.Valor);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Valor.GetHashCode() * 907) ^ Valor.GetHashCode();

                return hash;
            }
        }
    }
}