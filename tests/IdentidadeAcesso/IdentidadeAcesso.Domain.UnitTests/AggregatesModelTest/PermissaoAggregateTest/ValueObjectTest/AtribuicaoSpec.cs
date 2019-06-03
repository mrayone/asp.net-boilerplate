using FluentAssertions;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PermissaoAggregateTest.ValueObjectTest
{
    public class AtribuicaoSpec
    {
        [Fact(DisplayName = "Deve invalidar o estado se atribuição esta nula ou em branco.")]
        [Trait("Value Object", "Atribuição")]
        public void deve_invalidar_se_atribuicao_esta_nula_ou_em_branco()
        {
            //arrange
            var atr = AtribuicaoBuilder.ObterAtribuicaoNula();
            var atr2 = AtribuicaoBuilder.ObterAtribuicaoEmBranco();

            //act
            var isValid = atr.ValidationResult.IsValid;
            var isValid2 = atr2.ValidationResult.IsValid;

            //assert
            isValid.Should().BeFalse();
            isValid2.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve conter mensagens de erro se estado inválido.")]
        [Trait("Value Object", "Atribuição")]
        public void deve_conter_mensagens_de_erro_se_estado_invalido()
        {
            //arrange
            var atr = AtribuicaoBuilder.ObterAtribuicaoNula();
            var atr2 = AtribuicaoBuilder.ObterAtribuicaoEmBranco();
            var arr = new Dictionary<string, string>()
            {
                ["Valor Nulo/Vazio"] = "O valor deve ser preenchido.",
                ["Tipo Nulo/Vazio"] = "O tipo deve ser preenchido.",

            };

            //act
            var isValid = atr.ValidationResult.IsValid;
            var isValid2 = atr2.ValidationResult.IsValid;

            //assert
            isValid.Should().BeFalse();
            isValid2.Should().BeFalse();

            atr.ValidationResult.Erros.Should().Contain(arr);
            atr2.ValidationResult.Erros.Should().Contain(arr);
        }
    }
}
