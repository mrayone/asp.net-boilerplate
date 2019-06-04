using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders
{
    public class PerfilPermissaoBuilder
    {
        public static PerfilPermissao ObterPerfilPermissao()
        {
            return new PerfilPermissao(Guid.NewGuid(), true);
        }
    }
}
