using FluentAssertions;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
using System;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest
{
    public class UsuarioAggregateTest
    {

        [Fact(DisplayName = "Deve setar a data caso a ação de deletar seja invocada")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_setar_uma_data_caso_a_acao_de_deletar_seja_invocada()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            //act
            usuario.Deletar();
            //assert
            usuario.DeletadoEm?.Date.Should().Be(DateTime.Today);
        }
    }
}
