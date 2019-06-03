using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.Exceptions;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PerfilAggregateTest
{
    public class PerfilSpec
    {
        [Fact(DisplayName = "Deve invalidar o estado se houver erros na criação.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_invalidar_estado_se_houver_erros()
        {
            //arrange
            var perfil = PerfilBuilder.ObterPerfilInvalido();
            //act
            var isValid = perfil.EhValido();

            isValid.Should().BeFalse();
            perfil.Erros.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Não deve conter permissões duplicadas e em caso de adição a ultima permissão deve permanecer na lista.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void nao_deve_permitir_permissoes_duplicadas_e_em_caso_de_adicao_a_ultima_adicionada_deve_permanercer_na_lista()
        {
            //arrange
            var perfil = PerfilBuilder.ObterPerfilValido();
            var permissao = PerfilPermissaoBuilder.ObterPerfilPermissao();
            var permissao2 = permissao.Clone();

            //act
            var isValid = perfil.EhValido();
            permissao.DesativarPermissao();
            perfil.AdicionarPermissao(permissao);
            perfil.AdicionarPermissao(permissao2);

            //
            isValid.Should().BeTrue();
            perfil.Permissoes.Should().HaveCount(1);
            var elem = perfil.Permissoes.SingleOrDefault();
            elem.Ativo.Should().Be(permissao2.Ativo);
        }

        [Fact(DisplayName = "Deve gerar exception se deletar perfil que contem permissão.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_gerar_exception_se_deletar_perfil_que_contem_permissoes()
        {
            var perfil = PerfilBuilder.ObterPerfilValido();
            var permissao = PerfilPermissaoBuilder.ObterPerfilPermissao();

            perfil.AdicionarPermissao(permissao);

            Action act = () => perfil.DeletarPerfil();

            act.Should().Throw<IdentidadeAcessoDomainException>();
        }

        [Fact(DisplayName = "Deve desativar o perfil ao chamar o método deletar perfil.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_desativar_o_perfil_ao_chamar_metodo_deletar_perfil()
        {
            var perfil = PerfilBuilder.ObterPerfilValido();
            var permissao = PerfilPermissaoBuilder.ObterPerfilPermissao();

            Action act = () => perfil.DeletarPerfil();

            act.Should().NotThrow<IdentidadeAcessoDomainException>();
            perfil.Status.Should().Be(Status.Inativo);
        }
    }
}
