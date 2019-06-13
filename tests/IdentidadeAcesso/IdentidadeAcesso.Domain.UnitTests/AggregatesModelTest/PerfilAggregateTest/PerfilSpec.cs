using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
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
        [Fact(DisplayName = "Deve conter uma função que assina uma permissão e a mantenha ativa.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_conter_uma_funcao_que_assine_uma_permissao_e_a_mantenha_ativa()
        {
            //arrange
            var permissao = new Permissao(AtribuicaoBuilder.ObterAtribuicaoValida());
            var perfil = PerfilBuilder.ObterPerfil();

            //act
            perfil.AssinarPermissao(permissao.Id);

            var permissaoAssinada = perfil.PermissoesAssinadas.FirstOrDefault();

            permissaoAssinada.PermissaoId.Should().Be(permissao.Id);
            permissaoAssinada.Status.Should().Be(Status.Ativo);
        }

        [Fact(DisplayName = "Deve permitir cancelar a assinatura de permissão apenas a desativando.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_canelar_assinatura_de_permissao_a_desativando()
        {
            //arrange
            var permissao = new Permissao(AtribuicaoBuilder.ObterAtribuicaoValida());
            var perfil = PerfilBuilder.ObterPerfil();
            perfil.AssinarPermissao(permissao.Id);

            //act
            perfil.CancelarPermissao(permissao.Id);
            var permissaoAssinada = perfil.PermissoesAssinadas.FirstOrDefault();
            var isValid = perfil.EhValido();
            //assert
            permissaoAssinada.Status.Should().Be(Status.Inativo);
            perfil.Erros.Should().BeEmpty();

        }

        [Fact(DisplayName = "Deve ativar a permissão caso ela ja exista.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_ativar_a_permissao_caso_ela_ja_exista()
        {
            //arrange
            var permissao = new Permissao(AtribuicaoBuilder.ObterAtribuicaoValida());
            var perfil = PerfilBuilder.ObterPerfil();

            //act
            perfil.AssinarPermissao(permissao.Id);
            perfil.CancelarPermissao(permissao.Id);
            perfil.AssinarPermissao(permissao.Id);

            //assert
            var permissaoAssinada = perfil.PermissoesAssinadas.FirstOrDefault();

            perfil.EhValido().Should().BeTrue();
            perfil.PermissoesAssinadas.Should().HaveCount(1);
            permissaoAssinada.PermissaoId.Should().Be(permissao.Id);
            permissaoAssinada.Status.Should().Be(Status.Ativo);
        }
    }
}
