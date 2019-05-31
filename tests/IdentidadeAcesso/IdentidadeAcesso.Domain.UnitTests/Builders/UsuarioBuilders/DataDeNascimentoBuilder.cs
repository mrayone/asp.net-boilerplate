using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class DataDeNascimentoBuilder
    {
        public static DataDeNascimento ObterDataValida()
        {
            return new DataDeNascimento(22, 7, 1993);
        }

        public static DataDeNascimento ObterDataInvalida()
        {
            return new DataDeNascimento(22, 7, 2006);
        }
    }
}