using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders
{
    public class AtribuicaoBuilder
    {
        public static Atribuicao ObterAtribuicaoNula()
        {
            return new Atribuicao(null);
        }

        public static Atribuicao ObterAtribuicaoEmBranco()
        {
            return new Atribuicao("");
        }
    }
}