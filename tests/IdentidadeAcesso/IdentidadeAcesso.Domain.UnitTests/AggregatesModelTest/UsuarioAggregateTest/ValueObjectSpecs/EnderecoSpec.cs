using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class EnderecoSpec
    {

        [Fact(DisplayName = "Deve validar o estado nulo do objeto")]
        [Trait("Value Object", "Endereço")]
        public void deve_validar_estado_nulo_do_objeto()
        {
            //arrange
            var endereco = new Endereco(null, null, null, null, null, null, null);
            //act
            //assert

            endereco.ValidationResult.IsValid.Should().BeFalse();
            endereco.ValidationResult.Erros.Should().HaveCount(6);
        }

        [Fact(DisplayName = "Deve validar o estado em branco do objeto")]
        [Trait("Value Object", "Endereço")]
        public void deve_validar_estado_de_campos_vazios_do_objeto()
        {
            //arrange
            var endereco = new Endereco("", "", null, "", "", "", "");
            //act
            //assert

            endereco.ValidationResult.IsValid.Should().BeFalse();
            endereco.ValidationResult.Erros.Should().HaveCount(6);
        }


        [Fact(DisplayName = "Deve conter mensagem de erro se nulo")]
        [Trait("Value Object", "Endereço")]
        public void deve_conter_mensagem_de_erro_se_nulo()
        {
            var endereco = new Endereco(null, null, null, null, null, null, null);
            var dict = new Dictionary<string, string>()
            {
                ["Cidade Nula"] = "A cidade não pode ser nulo.",
                ["CEP Nulo"] = "O cep não pode ser nulo.",
                ["Estado Nulo"] = "O estado não pode ser nulo.",
                ["Bairro Nulo"] = "O bairro não pode ser nulo.",
                ["Numero Nulo"] = "O numero não pode ser nulo.",
                ["Logradouro Nulo"] = "O logradouro não pode ser nulo."
            };

            endereco.ValidationResult.Erros.Should().Contain(dict);
            endereco.ValidationResult.Erros.Should().HaveCount(6);
        }

        [Fact(DisplayName = "Deve conter mensagem de erro se vazio")]
        [Trait("Value Object", "Endereço")]
        public void deve_conter_mensagem_de_erro_se_vazio()
        {
            var endereco = new Endereco("", "", null, "", "", "", "");
            var dict = new Dictionary<string, string>()
            {
                ["Cidade Vazio"] = "A cidade não pode ser vazia.",
                ["CEP Vazio"] = "O cep não pode ser vazio.",
                ["Estado Vazio"] = "O estado não pode ser vazio.",
                ["Bairro Vazio"] = "O bairro não pode ser vazio.",
                ["Numero Vazio"] = "O numero não pode ser vazio.",
                ["Logradouro Vazio"] = "O logradouro não pode ser vazio."
            };

            endereco.ValidationResult.Erros.Should().Contain(dict);
            endereco.ValidationResult.Erros.Should().HaveCount(6);
        }

        [Fact(DisplayName = "Deve garantir que dois enderecos com os mesmos dados sejam o mesmo objeto")]
        [Trait("Value Object", "Endereço")]
        public void deve_garantir_que_dois_enderecos_com_os_mesmos_dados_sejam_o_mesmo_objeto()
        {
            var endereco = new Endereco("Rua Bla bla", "E489", null, "Vila Santa", "19480400", "Seilandia", "SL");
            var endereco2 = new Endereco("Rua Bla bla", "E489", null, "Vila Santa", "19480400", "Seilandia", "SL");

            endereco.Should().Be(endereco2);
        }
    }
}
