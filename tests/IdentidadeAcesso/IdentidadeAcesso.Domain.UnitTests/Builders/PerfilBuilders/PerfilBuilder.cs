using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders
{
    public class PerfilBuilder
    {
        public static Perfil ObterPerfilValido()
        {
            var ident = IdentificacaoBuilder.ObterValido();
            return new Perfil(ident);
        }
    }
}
