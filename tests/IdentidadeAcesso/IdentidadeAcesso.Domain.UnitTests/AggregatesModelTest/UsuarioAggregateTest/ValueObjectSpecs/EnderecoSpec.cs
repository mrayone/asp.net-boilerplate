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

        [Fact(DisplayName = "Deve validar dígitos do cep.")]
        [Trait("Value Object", "Endereço")]
        public void deve_validar_digitos_do_cep()
        {
            var endereco = new Endereco("Rua Bla bla", "E489", "Vila Santa", "194800400", "Seilandia", "SL");

            var isValid = endereco.ValidationResult.IsValid;

            isValid.Should().BeFalse();
            endereco.ValidationResult.Erros.Should().Contain(new List<string>()
            {
                "O CEP deve conter 8 dígitos."
            });
        }

        [Fact(DisplayName = "Deve validar o cep.")]
        [Trait("Value Object", "Endereço")]
        public void deve_validar_o_cep()
        {
            var endereco = new Endereco("Rua Bla bla", "E489", "Vila Santa", "1947000f", "Seilandia", "SL");

            var isValid = endereco.ValidationResult.IsValid;

            isValid.Should().BeFalse();
            endereco.ValidationResult.Erros.Should().Contain(new List<string>()
            {
                "O CEP é inválido."
            });
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
