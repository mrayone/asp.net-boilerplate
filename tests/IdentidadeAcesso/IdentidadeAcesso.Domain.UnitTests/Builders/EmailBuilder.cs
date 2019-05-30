using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders
{
    public class EmailBuilder
    {
        public static Email ObterEmailInvalido()
        {
            return new Email("js*@proseware.com");
        }

        public static Email ObterEmailValido()
        {
            return new Email("maycon.rayone@gmail.com");
        }
    }
}