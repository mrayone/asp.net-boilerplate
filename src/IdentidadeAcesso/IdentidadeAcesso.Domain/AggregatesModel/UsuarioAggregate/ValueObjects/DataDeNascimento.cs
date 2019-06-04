using IdentidadeAcesso.Domain.SeedOfWork;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class DataDeNascimento : ValueObject<DataDeNascimento>
    {
        public DateTime Data { get; private set; }
        public static readonly int IdadeMin = 14;

        public DataDeNascimento(int dia, int mes, int ano)
        {
            try
            {
                Data = new DateTime(ano, mes, dia);
                Validar();
            }
            catch (ArgumentOutOfRangeException)
            {
                ValidationResult.AdicionarErro("Os valores fornecidos representam uma data não representável.");
            }
        }

        private void Validar()
        {
            ValidarData();
        }

        private void ValidarData()
        {

            var totalDeAnos = (DateTime.Today - Data).TotalDays / 365.25;
            if (totalDeAnos < DataDeNascimento.IdadeMin)
            {
                ValidationResult.AdicionarErro(String.Format("A idade mínima requerida é de {0} anos.", DataDeNascimento.IdadeMin));
            }
        }

        protected override bool EqualsCore(DataDeNascimento other)
        {
            return Data.Equals(other.Data);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Data.GetHashCode() * 907) ^ Data.GetHashCode();

                return hash;
            }
        }
    }
}