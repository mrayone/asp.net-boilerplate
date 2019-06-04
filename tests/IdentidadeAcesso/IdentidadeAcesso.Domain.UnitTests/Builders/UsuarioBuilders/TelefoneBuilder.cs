using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class TelefoneBuilder
    {
        public static Telefone ObterTelefoneInvalido()
        {
            return new Telefone("558832816697");
        }

        public static Telefone ObterTelefoneValido()
        {
            return new Telefone("+558832816597");
        }
    }
}