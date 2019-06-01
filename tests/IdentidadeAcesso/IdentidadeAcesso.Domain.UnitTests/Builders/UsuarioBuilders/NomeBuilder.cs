using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class NomeBuilder
    {
        public static NomeCompleto ObterNomeInvalido()
        {
            return new NomeCompleto("Fake User", null);
        }

        public static NomeCompleto ObterNomeValido()
        {
            return new NomeCompleto("Fake", "Usuario Fake");
        }
    }
}