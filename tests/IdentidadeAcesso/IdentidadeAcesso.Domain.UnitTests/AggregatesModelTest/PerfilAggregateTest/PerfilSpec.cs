using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.Exceptions;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PerfilAggregateTest
{
    public class PerfilSpec
    {
        [Fact(DisplayName = "Deve adicionar permissão se perfil valido")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_adicionar_permissoes_se_perfil_valido()
        {
            var perfil = PerfilBuilder.ObterPerfilValido();
            var atribuicao = AtribuicaoBuilder.ObterAtribuicaoValida();
            var permissao = new Permissao(atribuicao);

            perfil.EhValido().Should().BeTrue();
            perfil.AdicionarPermissao(permissao);

            perfil.Permissoes.Should().Contain(permissao);
        }

        [Fact(DisplayName = "Deve retornar erro se permissão ja existir no perfil.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_retornar_erro_se_permissao_ja_existir_no_perfil()
        {
            var perfil = PerfilBuilder.ObterPerfilValido();
            var atribuicao = AtribuicaoBuilder.ObterAtribuicaoValida();
            var permissaoMock = new Permissao(atribuicao);

            perfil.AdicionarPermissao(permissaoMock);
            perfil.AdicionarPermissao(permissaoMock);

            perfil.EhValido().Should().BeFalse();
            perfil.Erros.Should().NotBeEmpty();
            perfil.Erros.Should().HaveCount(1);
        }

        [Fact(DisplayName = "Deve permitir desativar uma permissão")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_permitir_desativar_uma_permissao()
        {
            var perfil = PerfilBuilder.ObterPerfilValido();
            var atribuicao = AtribuicaoBuilder.ObterAtribuicaoValida();
            var permissaoMock = new Permissao(atribuicao);

            perfil.AdicionarPermissao(permissaoMock);
            perfil.DesativarPermissao(permissaoMock);

            perfil.EhValido().Should().BeTrue();
            perfil.Permissoes.FirstOrDefault(p => p == permissaoMock).Status.Should().Be(Status.Inativo);
        }

        /*
         Deve permitir deletar um perfil se, não houver usuarios e permissões ativas.
         */
        [Fact(DisplayName = "Deve gerar erro ao deletar perfil com permissões ativas.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_gerar_erro_ao_deletar_perfil_com_permissoes_ativas()
        {
            //arrange
            var perfil = PerfilBuilder.ObterPerfilValido();
            var permissaoMock = new Mock<Permissao>(new Atribuicao("Usuário", "Atualizar"));
            var permissaoMock2 = new Mock<Permissao>(new Atribuicao("Usuário", "Excluir"));

            //act
            perfil.AdicionarPermissao(permissaoMock.Object);
            perfil.AdicionarPermissao(permissaoMock2.Object);
            perfil.DeletarPerfil();

            //assert
            perfil.EhValido().Should().BeFalse();
            perfil.Permissoes.Should().HaveCount(2);
            perfil.Erros.Should().Contain(new List<string>()
            {
                "Este perfil não pode ser deletado pois possui permissões ativas."
            });
        }

        [Fact(DisplayName = "Deve gerar erro ao deletar perfil com usuario vinculado.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_gerar_erro_ao_deletar_perfil_com_usuario_vinculado()
        {
           
        }
    }
}
