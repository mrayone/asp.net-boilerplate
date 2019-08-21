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
        public PermissaoSpec()
        {

        }
        [Fact(DisplayName = "Deve disparar exceção se definir atribuição nula.")]
        [Trait("Raiz de Agregação", "Permissão")]
        public void Deve_Disparar_Excecao_Se_Definir_Atribuicao_Nula()
        {
            //arrange
            var permissao = PermissaoBuilder.ObterPermissaoFake();
            //act
            Action act = () => { permissao.DefinirAtribuicao(null); };
            //assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
