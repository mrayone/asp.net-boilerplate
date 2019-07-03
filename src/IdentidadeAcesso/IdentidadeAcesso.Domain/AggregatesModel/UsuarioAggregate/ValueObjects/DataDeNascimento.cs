using IdentidadeAcesso.Domain.SeedOfWork;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class DataDeNascimento : ValueObject<DataDeNascimento>
    {
        public DateTime Data { get; private set; }

        public DataDeNascimento(DateTime data)
        {
            Data = data;
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