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
            endereco.ValidationResult.Erros.Should().HaveCount(7);
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
                ["Cidade Nulo/Vazio"] = "A cidade deve ser fornecida.",
                ["CEP Nulo/Vazio"] = "O cep deve ser fornecido.",
                ["Estado Nulo/Vazio"] = "O estado deve ser fornecido.",
                ["Bairro Nulo/Vazio"] = "O bairro deve ser fornecido.",
                ["Numero Nulo/Vazio"] = "O numero deve ser fornecido.",
                ["Complemento Nulo"] = "O complemento não pode ser nulo.",
                ["Logradouro Nulo/Vazio"] = "O logradouro deve ser fornecido."
            };

            endereco.ValidationResult.Erros.Should().Contain(dict);
            endereco.ValidationResult.Erros.Should().HaveCount(7);
        }

        [Fact(DisplayName = "Deve conter mensagem de erro se vazio")]
        [Trait("Value Object", "Endereço")]
        public void deve_conter_mensagem_de_erro_se_vazio()
        {
            var endereco = new Endereco("", "", "", "", "", "");
            var dict = new Dictionary<string, string>()
            {
                ["Cidade Nulo/Vazio"] = "A cidade deve ser fornecida.",
                ["CEP Nulo/Vazio"] = "O cep deve ser fornecido.",
                ["Estado Nulo/Vazio"] = "O estado deve ser fornecido.",
                ["Bairro Nulo/Vazio"] = "O bairro deve ser fornecido.",
                ["Numero Nulo/Vazio"] = "O numero deve ser fornecido.",
                ["Logradouro Nulo/Vazio"] = "O logradouro deve ser fornecido."
            };

            endereco.ValidationResult.Erros.Should().Contain(dict);
            endereco.ValidationResult.Erros.Should().HaveCount(6);
        }

        [Fact(DisplayName = "Deve garantir que dois enderecos com os mesmos dados sejam o mesmo objeto")]
        [Trait("Value Object", "Endereço")]
        public void deve_garantir_que_dois_enderecos_com_os_mesmos_dados_sejam_o_mesmo_objeto()
        {
            var endereco = new Endereco("Rua Bla bla", "E489", "Vila Santa", "19480400", "Seilandia", "SL");
            var endereco2 = new Endereco("Rua Bla bla", "E489", "Vila Santa", "19480400", "Seilandia", "SL");

            endereco.Should().Be(endereco2);
        }
    }
}
