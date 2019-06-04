using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders
{
    public class PerfilBuilder
    {
        public static Perfil ObterPerfilInvalido()
        {
            var ident = IdentificacaoBuilder.ObterBranco();
            return new Perfil(ident);
        }

        public static Perfil ObterPerfilValido()
        {
            var ident = IdentificacaoBuilder.ObterValido();
            return new Perfil(ident);
        }
    }
}
