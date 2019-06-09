using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class DataDeNascimentoBuilder
    {
        public static DataDeNascimento ObterDataValida()
        {
            var dataNascimento = new DateTime(1993, 7, 22);
            return new DataDeNascimento(dataNascimento);
        }

        public static DataDeNascimento ObterDataInvalida()
        {
            var dataNascimento = new DateTime(2007, 7, 22);
            return new DataDeNascimento(dataNascimento);
        }
    }
}