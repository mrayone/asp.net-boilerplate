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

        //TODO: Validar se CEP é valido.

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
