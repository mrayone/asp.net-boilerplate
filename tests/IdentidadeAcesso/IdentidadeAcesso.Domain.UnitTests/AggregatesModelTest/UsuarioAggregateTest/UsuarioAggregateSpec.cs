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
        public void Deve_Setar_Uma_Data_Caso_a_Acao_De_Deletar_Seja_Invocada()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            //act
            usuario.Deletar();
            //assert
            usuario.DeletadoEm?.Date.Should().Be(DateTime.Today);
        }

        [Fact(DisplayName = "Deve disparar exceção se atribuir VO celular nulo.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void Deve_Disparar_Excecao_Se_Atribuir_Celular_Nulo()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            //act
            Action act = () => { usuario.AdicionarCelular(null); };
            //assert

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "Deve disparar exceção se atribuir VO endereço nulo.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void Deve_Disparar_Excecao_Se_Atribuir_Endereco_Nulo()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            //act+
            Action act = () => { usuario.AdicionarEndereco(null); };
            //assert

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
