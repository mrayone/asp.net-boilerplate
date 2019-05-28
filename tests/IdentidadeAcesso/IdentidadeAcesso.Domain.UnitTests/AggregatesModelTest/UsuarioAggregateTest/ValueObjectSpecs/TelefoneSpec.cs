using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class TelefoneSpec
    {
        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve garantir que dois telefones com o mesmo digito sejam o mesmo objeto")]
        public void deve_garantir_que_dois_telefones_com_mesmo_digito_sejam_o_mesmo_objeto()
        {
            var telefone = new Telefone("+551832815597");
            var telefone2 = new Telefone("+551832815597");

            telefone.Should().Be(telefone2);
        }

        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve invalidar o estado em caso de valores nulos ou vazios serem setados")]
        public void deve_invalidar_o_estado_em_caso_de_valores_nulos_ou_vazios_serem_setados()
        {
            var telefone = new Telefone(null);
            var telefone2 = new Telefone("");


            telefone.ValidationResult.IsValid.Should().BeFalse();
            telefone2.ValidationResult.IsValid.Should().BeFalse();
        }


        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve retornar mensagens de erro quando valores nulos ou vazios são setados")]
        public void deve_retornar_mensaagens_de_erro_quando_valores_nulos_ou_vazios_sao_setados()
        {
            var telefone = new Telefone(null);
            var telefone2 = new Telefone("");

            var erros1 = new Dictionary<string, string>()
            {
                ["Telefone Nulo"] = "O telefone não pode ser nulo.",
            };

            var erros2 = new Dictionary<string, string>()
            {
                ["Telefone Vazio"] = "O telefone não pode ser vazio.",
            };

            telefone.ValidationResult.Erros.Should().Contain(erros1);
            telefone2.ValidationResult.Erros.Should().Contain(erros2);
            telefone.ValidationResult.IsValid.Should().BeFalse();
            telefone2.ValidationResult.IsValid.Should().BeFalse();
        }

        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve retornar mensagens de erro quando valores estão com tamanho inválidos")]
        public void deve_retornar_erro_para_tamanho_invalido_de_dados()
        {
            var telefone = new Telefone("+5518328155976");

            var erros1 = new Dictionary<string, string>()
            {
                ["Telefone Tamanho Inválido"] = "O telefone não pode exceder 13 caracteres.",
            };

            telefone.ValidationResult.Erros.Should().Contain(erros1);
            telefone.ValidationResult.IsValid.Should().BeFalse();
        }

        [Trait("Value Object", "Telefone")]
        [Theory(DisplayName = "Deve manter seu estado inválido e retornar erro se um telefone inválido for fornecido")]
        [InlineData("5518981928663", false)]
        [InlineData(".551898192866", false)]
        [InlineData(".55..98192866", false)]
        [InlineData("-------------", false)]
        [InlineData("-5598192866", false)]
        [InlineData("-551898192866", false)]
        public void deve_manter_seu_estado_invalido_e_retornar_erro_se_um_telefone_invalido_for_fornecido(string numero, bool isValid)
        {
            var tel = new Telefone(numero);
            var dict = new Dictionary<string, string>()
            {
                ["Telefone Inválido"] = "O telefone com formato inválido.",
            };

            tel.ValidationResult.IsValid.Should().Be(isValid);
            tel.ValidationResult.Erros.Should().Contain(dict);
        }

        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve ter seu estado válido se inserido os dados corretamente")]
        public void deve_ter_seu_estado_valido_se_inserido_os_dados_corretamente()
        {
            var tel = new Telefone("+551832815597");

            tel.ValidationResult.IsValid.Should().BeTrue();
            tel.ValidationResult.Erros.Should().HaveCount(0);
        }
    }
}
