using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders
{
    public class DataDeNascimentoBuilder
    {
        public static DataDeNascimento ObterDataInvalida()
        {
            return new DataDeNascimento(22, 7, 2006);
        }
    }
}