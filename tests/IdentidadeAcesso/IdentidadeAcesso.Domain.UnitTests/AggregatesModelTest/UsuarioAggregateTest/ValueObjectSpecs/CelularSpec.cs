using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class CelularSpec
    {
        [Trait("Value Object", "Celular")]
        [Fact(DisplayName = "Deve garantir que dois celulares com o mesmo digito sejam o mesmo objeto")]
        public void deve_garantir_que_dois_telefones_com_mesmo_digito_sejam_o_mesmo_objeto()
        {
            var cel = new Celular("+5518981928663");
            var cel2 = new Celular("+5518981928663");

            cel.Should().Be(cel2);
        }

        [Trait("Value Object", "Celular")]
        [Fact(DisplayName = "Deve invalidar o estado em caso de valores nulos ou vazios serem setados")]
        public void deve_invalidar_o_estado_em_caso_de_valores_nulos_ou_vazios_serem_setados()
        {
            var cel = new Celular(null);
            var cel2 = new Celular("");


            cel.ValidationResult.IsValid.Should().BeFalse();
            cel2.ValidationResult.IsValid.Should().BeFalse();
        }

        [Trait("Value Object", "Celular")]
        [Fact(DisplayName = "Deve retornar mensagens de erro quando valores nulos ou vazios são setados")]
        public void deve_retornar_mensaagens_de_erro_quando_valores_nulos_ou_vazios_sao_setados()
        {
            var celular = new Celular(null);
            var celular2 = new Celular("");

            var erros1 = new Dictionary<string, string>()
            {
                ["Celular Nulo"] = "O celular não pode ser nulo.",
            };

            var erros2 = new Dictionary<string, string>()
            {
                ["Celular Vazio"] = "O celular não pode ser vazio.",
            };

            celular.ValidationResult.Erros.Should().Contain(erros1);
            celular2.ValidationResult.Erros.Should().Contain(erros2);

            celular.ValidationResult.IsValid.Should().BeFalse();
            celular2.ValidationResult.IsValid.Should().BeFalse();
        }

        [Trait("Value Object", "Celular")]
        [Fact(DisplayName = "Deve retornar mensagem de erro quando o número do celular for de tamanho inválido")]
        public void deve_retornar_mensagem_de_erro_quando_numero_do_celular_for_de_tamanho_invalido()
        {
            var celular = new Celular("+55189819286693");

            var erros1 = new Dictionary<string, string>()
            {
                ["Celular de Tamanho Inválido"] = "O celular não pode exceder 14 caracteres.",
            };

            celular.ValidationResult.Erros.Should().Contain(erros1);
            celular.ValidationResult.IsValid.Should().BeFalse();

        }


        [Trait("Value Object", "Celular")]
        [Theory(DisplayName = "Deve manter seu estado inválido e retornar erro se um celular inválido for fornecido")]
        [InlineData("55189819286632", false)]
        [InlineData(".5518981928663", false)]
        [InlineData(".55..981928663", false)]
        [InlineData("--------------", false)]

        [InlineData("-55981928663", false)]
        [InlineData("-5518981928663", false)]
        public void deve_manter_seu_estado_invalido_e_retornar_erro_se_um_celular_invalido_for_fornecido(string numero, bool isValid)
        {
            var cel = new Celular(numero);
            var dict = new Dictionary<string, string>()
            {
                ["Celular Inválido"] = "O celular com formato inválido.",
            };

            cel.ValidationResult.IsValid.Should().Be(isValid);
            cel.ValidationResult.Erros.Should().Contain(dict);
        }

        [Trait("Value Object", "Celular")]
        [Fact(DisplayName = "Deve ter seu estado válido se inserido os dados corretamente")]
        public void deve_ter_seu_estado_valido_se_inserido_os_dados_corretamente()
        {
            var cel = new Celular("+5518981928663");

            cel.ValidationResult.IsValid.Should().BeTrue();
            cel.ValidationResult.Erros.Should().HaveCount(0);
        }
    }
}
