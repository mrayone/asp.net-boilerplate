using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class CelularBuilder
    {

        public static NumerosContato ObterCelularValido()
        {
            return new NumerosContato("+5518981928663", "");
        }
    }
}