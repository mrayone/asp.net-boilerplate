using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders
{
    public class PerfilBuilder
    {
        public static Perfil ObterPerfil()
        {
            var ident = IdentificacaoBuilder.ObterValido();
            var perfil = new Perfil(ident);
            perfil.AssinarPermissao(Guid.NewGuid());
            return new Perfil(ident);
        }
    }
}
