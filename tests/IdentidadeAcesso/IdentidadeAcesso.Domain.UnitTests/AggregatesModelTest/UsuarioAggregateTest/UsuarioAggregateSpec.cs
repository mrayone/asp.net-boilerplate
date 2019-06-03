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

        [Fact(DisplayName = "Deve marcar status como 'inativo' se o método deletar for invocado")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_marcar_status_como_inativo_se_o_metodo_deletar_for_invocado()
        {
            var usuario = UsuarioBuilder.ObterUsuarioValido();

            //act
            usuario.Deletar();

            usuario.Status.Should().Be(Status.Inativo);
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
