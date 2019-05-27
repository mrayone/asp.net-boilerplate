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
        [Fact(DisplayName = "Deve invalidar o estado em caso de valores nulos ou em vazios são setados")]
        public void deve_invalidar_o_estado_em_caso_de_valores_nulos_ou_em_vazios_sao_setados()
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
                ["Número Nulo"] = "O número não pode ser nulo.",
            };

            var erros2 = new Dictionary<string, string>()
            {
                ["Número Vazio"] = "O número não pode ser vazio.",
            };

            telefone.ValidationResult.Erros.Should().Contain(erros1);
            telefone2.ValidationResult.Erros.Should().Contain(erros2);
        }

        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve retornar mensagens de erro quando valores estão com tamanho inválidos")]
        public void deve_retornar_erro_para_tamanho_invalido_de_dados()
        {
            var telefone = new Telefone("+5518328155976");

            var erros1 = new Dictionary<string, string>()
            {
                ["Número Tamanho Inválido"] = "O número não pode ser exceder 13 caracteres.",
            };

            telefone.ValidationResult.Erros.Should().Contain(erros1);
        }
    }
}
