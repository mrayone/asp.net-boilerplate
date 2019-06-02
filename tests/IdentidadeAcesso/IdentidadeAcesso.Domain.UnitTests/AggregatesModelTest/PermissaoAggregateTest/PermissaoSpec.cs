using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PermissaoAggregateTest
{
    public class PermissaoSpec
    {

        [Fact(DisplayName = "Deve conter o estado invalido e erros.")]
        [Trait("Raiz de Agregação","Permissao")]
        public void deve_conter_o_estado_invalido_e_erros()
        {
            //arrange
            var atribuicao = AtribuicaoBuilder.ObterAtribuicaoEmBranco();
            var permissao = new Permissao(atribuicao);
            var key = new List<string>()
            {
                "Atribuição"
            };
            //act
            var isValid = permissao.EhValido();

            //assert
            isValid.Should().BeFalse();
            permissao.Erros.Should().HaveCount(1);
            permissao.Erros.Select(k => k.Key).Should().BeEquivalentTo(key);
        }
    }
}
