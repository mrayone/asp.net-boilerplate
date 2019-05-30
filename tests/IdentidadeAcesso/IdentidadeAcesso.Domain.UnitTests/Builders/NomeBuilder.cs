using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders
{
    public class NomeBuilder
    {
        public static Nome ObterNomeInvalido()
        {
            return new Nome("Maycon", null);
        }

        public static Nome ObterNomeValido()
        {
            return new Nome("Maycon", "Rodrigues Xavier");
        }
    }
}