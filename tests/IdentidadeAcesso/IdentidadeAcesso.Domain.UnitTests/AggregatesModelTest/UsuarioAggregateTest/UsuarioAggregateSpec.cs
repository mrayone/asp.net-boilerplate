using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
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
        
        [Fact(DisplayName = "Deve retornar estado inválido e erros")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_retornar_estado_invalido_e_erros()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioInvalido();
            var chaves = new List<string>()
            {
                "Nome",
                "Sexo",
                "Email",
                "CPF",
                "DataDeNascimento"
            };
            //act
            var valido = usuario.EhValido();

            //assert
            valido.Should().BeFalse();
            usuario.Erros.Keys.Should().Contain(chaves);
        }


        [Fact(DisplayName = "Deve validar apenas chaves que estejam com erros.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_validar_apenas_chaves_que_estejam_com_erros()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioParcialmenteInvalido();
            var chaves = new List<string>()
            {
                "Sexo",
                "CPF",
                "DataDeNascimento"
            };
            //act
            var valido = usuario.EhValido();

            //assert
            valido.Should().BeFalse();
            usuario.Erros.Select(k => k.Key).Should().Equal(chaves.Select(c => c));
        }

        [Fact(DisplayName = "Deve manter o estado válido se não houver erros.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_manter_o_estado_valido_se_nao_houver_erros()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();

            //act
            var valido = usuario.EhValido();

            //assert
            valido.Should().BeTrue();
            usuario.Erros.Should().BeEmpty();
        }

        [Fact(DisplayName = "Deve validar se endereço é válido.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_validar_se_endereco_e_valido()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            var endereco = EnderecoBuilder.ObterEnderecoInvalido();
            //act
            usuario.AdicionarEndereco(endereco);
            var valido = usuario.EhValido();

            //assert
            valido.Should().BeFalse();
            usuario.Erros.Select(e => e.Key).Should().Equal("Endereco");
            usuario.Endereco.Should().BeNull();

        }

        [Fact(DisplayName = "Deve validar se telefone é válido.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_validar_se_telefone_e_valido()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            var telefone = TelefoneBuilder.ObterTelefoneInvalido();
            //act
            usuario.AdicionarTelefone(telefone);
            var valido = usuario.EhValido();

            //assert
            valido.Should().BeFalse();
            usuario.Erros.Select(e => e.Key).Should().Equal("Telefone");
            usuario.Telefone.Should().BeNull();
        }

        [Fact(DisplayName = "Deve validar se celular é válido.")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_validar_se_celular_e_valido()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            var celular = CelularBuilder.ObterCelularInvalido();
            //act
            usuario.AdicionarCelular(celular);
            var valido = usuario.EhValido();

            //assert
            valido.Should().BeFalse();
            usuario.Erros.Select(e => e.Key).Should().Equal("Celular");
            usuario.Celular.Should().BeNull();
        }

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

        [Fact(DisplayName = "Deve invalidar um usuário preenchido completamente")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_invalidar_um_usuario_preenchido_completamente()
        {
            //arr
            var usuario = UsuarioBuilder.ObterUsuarioInvalido();
            var celular = CelularBuilder.ObterCelularInvalido();
            var telefone = TelefoneBuilder.ObterTelefoneInvalido();
            var endereco = EnderecoBuilder.ObterEnderecoInvalido();
            var chaves = new List<string>()
            {
                "Nome",
                "Sexo",
                "Email",
                "CPF",
                "DataDeNascimento",
                "Email",
                "Telefone",
                "Celular",
                "Endereco"
            };

            //act
            usuario.AdicionarTelefone(telefone);
            usuario.AdicionarCelular(celular);
            usuario.AdicionarEndereco(endereco);

            var valido = usuario.EhValido();
            //assert

            valido.Should().BeFalse();
            usuario.Erros.Select(e => e.Key).Equals(chaves.Select(c => c));
        }

        [Fact(DisplayName = "Deve validar um usuário preenchido completamente")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_validar_um_usuario_preenchido_completamente()
        {
            //arr
            var usuario = UsuarioBuilder.ObterUsuarioValido();
            var celular = CelularBuilder.ObterCelularValido();
            var telefone = TelefoneBuilder.ObterTelefoneValido();
            var endereco = EnderecoBuilder.ObterEnderecoValido();

            //act
            usuario.AdicionarTelefone(telefone);
            usuario.AdicionarCelular(celular);
            usuario.AdicionarEndereco(endereco);

            var valido = usuario.EhValido();
            //assert

            valido.Should().BeTrue();
        }
    }
}
