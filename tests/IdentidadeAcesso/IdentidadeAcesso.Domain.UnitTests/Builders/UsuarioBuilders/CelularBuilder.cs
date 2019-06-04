using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class CelularBuilder
    {
        public static Celular ObterCelularInvalido()
        {
            return new Celular("551898192863");
        }

        public static Celular ObterCelularValido()
        {
            return new Celular("+5518981928663");
        }
    }
}