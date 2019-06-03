using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest
{
    public class UsuarioAggregateTest
    {

        [Fact(DisplayName = "Deve marcar status como 'inativo' se o método deletar for invocado")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_marcar_status_como_inativo_se_o_metodo_deletar_for_invocado()
        {
            var usuario = UsuarioBuilder.ObterUsuarioValido();

            //act
            usuario.Deletar();

            usuario.Status.Equals(Status.Inativo);
            usuario.Status.Id.Equals(Status.Inativo.Id);
            usuario.Status.Nome.Equals(Status.Inativo.Nome);
        }
    }
}
