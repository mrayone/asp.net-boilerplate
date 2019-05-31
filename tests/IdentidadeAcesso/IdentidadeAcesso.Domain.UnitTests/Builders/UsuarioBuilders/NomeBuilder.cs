using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class NomeBuilder
    {
        public static Nome ObterNomeInvalido()
        {
            return new Nome("Fake User", null);
        }

        public static Nome ObterNomeValido()
        {
            return new Nome("Fake", "Usuario Fake");
        }
    }
}