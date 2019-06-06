using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.Exceptions;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PerfilAggregateTest
{
    public class PerfilSpec
    {
        /*
     Deve validar seu rótulo[x].
     Deve adicionar se PerfilPermissao for valido permissões[].
     Deve conter um Perfil Atrelado[].
     Não pode haver permissões duplicadas[].
     Deve permitir desativar uma determinada permissão[].
     */
        //[Fact(DisplayName = "Deve validar seu rotulo em caso de nulo")]
        //[Trait("Raiz de Agregação", "PerfilPermissão")]
        //public void deve_validar_seu_rotulo_em_caso_de_nulo()
        //{
        //    var rotulo = new Rotulo(null);
        //    var perfilPermissao = new Perfil(rotulo, Guid.NewGuid());

        //    var isValid = perfilPermissao.EhValido();

        //    isValid.Should().BeFalse();
        //    perfilPermissao.Erros.Should().NotBeEmpty();
        //}

        //[Fact(DisplayName = "Deve validar se o id do perfil é vazio.")]
        //[Trait("Raiz de Agregação", "PerfilPermissão")]
        //public void deve_validar_perfilGuid_em_caso_de_vazio()
        //{
        //    var rotulo = new Rotulo(null);
        //    var perfilPermissao = new Perfil(rotulo, Guid.Empty);

        //    var isValid = perfilPermissao.EhValido();

        //    isValid.Should().BeFalse();
        //    perfilPermissao.Erros.Should().HaveCount(2);
        //}

        //[Fact(DisplayName = "Deve adicionar permissão se perfil valido")]
        //[Trait("Raiz de Agregação", "PerfilPermissão")]
        //public void deve_adicionar_permissoes_se_perfil_valido()
        //{
        //    var perfilPermissao = PerfilPermissaoBuilder.ObterValido();
        //    var permissao = PermissaoBuilder.ObterValido();

        //    perfilPermissao.EhValido().Should().BeTrue();
        //    perfilPermissao.AdicionarPermissao(permissao);

        //    perfilPermissao.Permissoes.Should().Contain(permissao);
        //}

        //[Fact(DisplayName = "Deve retornar erro ao adicionar permissão se perfil invalido.")]
        //[Trait("Raiz de Agregação", "PerfilPermissão")]
        //public void deve_retornar_erro_ao_adicionar_permissao_se_perfil_invalido()
        //{
        //    var rotulo = new Rotulo(null);
        //    var perfilPermissao = new Perfil(rotulo, Guid.Empty);
        //    var permissao = PermissaoBuilder.ObterValido();

        //    perfilPermissao.AdicionarPermissao(permissao);

        //    perfilPermissao.EhValido().Should().BeFalse();
        //    perfilPermissao.Erros.Should().NotBeEmpty();
        //}

        //[Fact(DisplayName = "Deve retornar erro ao adicioanr permissão inválida.")]
        //[Trait("Raiz de Agregação", "PerfilPermissão")]
        //public void deve_retornar_excessao_ao_adicionar_permissao_invalida()
        //{
        //    var perfilPermissao = PerfilPermissaoBuilder.ObterValido();
        //    var permissao = PermissaoBuilder.ObterInvalido();

        //    perfilPermissao.AdicionarPermissao(permissao);

        //    perfilPermissao.EhValido().Should().BeFalse();
        //    perfilPermissao.Erros.Should().NotBeEmpty();
        //    perfilPermissao.Erros.Should().HaveCount(1);
        //}
    }
}
