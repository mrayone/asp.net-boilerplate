using FluentAssertions;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
using System;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest
{
    public class UsuarioAggregateTest
    {
        [Fact(DisplayName = "Deve retonar erros caso estado inválido.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_retornar_erros_caso_estado_invalido()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioInvalido();

            //act
            var isValid = usuario.EhValido();

            //assert
            isValid.Should().BeFalse();
            usuario.Erros.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve setar a data caso a ação de deletar seja invocada")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_setar_uma_data_caso_a_acao_de_deletar_seja_invocada()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            //act
            usuario.Deletar();
            //assert
            usuario.DeletadoEm.Date.Should().Be(DateTime.Today);
        }


        [Fact(DisplayName = "Deve retornar estado falso ao adicionar telefone, endereço e celular inválido.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_retornar_estado_falso_ao_adicionar_telefone_endereco_e_celular_invalido()
        {
            var usuario = UsuarioBuilder.ObterUsuarioValido();

            //act
            usuario.AdicionarCelular(CelularBuilder.ObterCelularInvalido());
            usuario.AdicionarEndereco(EnderecoBuilder.ObterEnderecoInvalido());
            usuario.AdicionarTelefone(TelefoneBuilder.ObterTelefoneInvalido());
            var isValid = usuario.EhValido();

            isValid.Should().BeFalse();
            usuario.Erros.Should().NotBeEmpty();
        }
    }
}
