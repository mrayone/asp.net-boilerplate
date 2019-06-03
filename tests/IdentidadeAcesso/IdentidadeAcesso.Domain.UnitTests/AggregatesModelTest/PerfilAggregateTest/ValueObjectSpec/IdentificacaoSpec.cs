using FluentAssertions;
using IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders;
using System.Collections.Generic;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PerfilAggregateTest.ValueObjectSpec
{
    public class IdentificacaoSpec
    {
        [Fact(DisplayName = "Deve invalidar estado se definir nome e descrição nulos.")]
        [Trait("Value Object", "Identificacao")]
        public void deve_invalidar_estado_se_definir_nome_e_descricao_nulo()
        {
            //arr
            var identificacao = IdentificacaoBuilder.ObterNulo();

            //act
            var isValid = identificacao.ValidationResult.IsValid;

            //assert
            isValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve invalidar estado se definir nome e descrição branco.")]
        [Trait("Value Object", "Identificação")]
        public void deve_invalidar_estado_se_definir_nome_e_descricao_em_branco()
        {
            //arr
            var identificacao = IdentificacaoBuilder.ObterBranco();

            //act
            var isValid = identificacao.ValidationResult.IsValid;

            //assert
            isValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar mensagens de erro caso nome e descrição nulo ou em branco.")]
        [Trait("Value Object", "Identificação")]
        public void deve_retornar_mensagens_de_erro_caso_nulo_ou_branco()
        {
            //arr
            var emBranco = IdentificacaoBuilder.ObterBranco();
            var nulo = IdentificacaoBuilder.ObterNulo();
            var dic1 = new Dictionary<string, string>()
            {
                ["Nome Nulo/Vazio"] = "O nome precisa ser preenchido.",
                ["Descrição Nulo/Vazio"] = "A descrição precisa ser preenchida."
            };

            //act
            var isValid = emBranco.ValidationResult.IsValid;
            var isValido2 = nulo.ValidationResult.IsValid;
            //assert
            isValid.Should().BeFalse();
            isValido2.Should().BeFalse();

            nulo.ValidationResult.Erros.Should().Contain(dic1);
            emBranco.ValidationResult.Erros.Should().Contain(dic1);
        }

        [Fact(DisplayName = "Deve manter o estado inválido se somente nome estiver nulo ou em branco.")]
        [Trait("Value Object", "Identificação")]
        public void deve_manter_estado_invalido_se_somente_nome_estiver_nulo_ou_branco()
        {
            //arr
            var emBranco = IdentificacaoBuilder.ObterComNomeEmBranco();
            var nulo = IdentificacaoBuilder.ObterComNomeNulo();
            var dic1 = new Dictionary<string, string>()
            {
                ["Nome Nulo/Vazio"] = "O nome precisa ser preenchido.",
            };

            //act
            var isValid = emBranco.ValidationResult.IsValid;
            var isValido2 = nulo.ValidationResult.IsValid;
            //assert
            isValid.Should().BeFalse();
            isValido2.Should().BeFalse();

            nulo.ValidationResult.Erros.Should().Contain(dic1);
        }


        [Fact(DisplayName = "Deve manter o estado inválido se somente descrição estiver nula ou em branco.")]
        [Trait("Value Object", "Identificação")]
        public void deve_manter_estado_invalido_se_somente_descricao_estiver_nulo_ou_branco()
        {
            //arr
            var emBranco = IdentificacaoBuilder.ObterComDescricaoEmBranco();
            var nulo = IdentificacaoBuilder.ObterComDescricaoNula();
            var dic1 = new Dictionary<string, string>()
            {
                ["Descrição Nulo/Vazio"] = "A descrição precisa ser preenchida."
            };

            //act
            var isValid = emBranco.ValidationResult.IsValid;
            var isValido2 = nulo.ValidationResult.IsValid;
            //assert
            isValid.Should().BeFalse();
            isValido2.Should().BeFalse();

            nulo.ValidationResult.Erros.Should().Contain(dic1);
            emBranco.ValidationResult.Erros.Should().Contain(dic1);
        }

        [Fact(DisplayName = "Deve manter seu estado válido caso não tenha erros.")]
        [Trait("Value Object", "Identificação")]
        public void deve_manter_seu_estado_valido_caso_nao_tenha_erros()
        {
            var ident = IdentificacaoBuilder.ObterValido();

            var isValid = ident.ValidationResult.IsValid;

            isValid.Should().BeTrue();
            ident.ValidationResult.Erros.Should().BeEmpty();
        }
    }
}
