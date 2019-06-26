using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders
{
    public abstract class PermissaoBuilder
    {
        public static Permissao ObterPermissaoFake()
        {
            return new Permissao(AtribuicaoBuilder.ObterAtribuicaoValida());
        }
    }
}
