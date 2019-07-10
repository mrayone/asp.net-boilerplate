using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class CPFSpec
    {
        public CPFSpec()
        { }


        [Fact(DisplayName = "Deve retornar um CPF somente com os digitos se houver mascara")]
        [Trait("Value Object", "CPF")]
        public void deve_retornar_um_cpf_somente_com_digitos_se_houver_mascara()
        {
            //arrage
            var cpfStr = "017.942.000-37";
            //act
            var cpfLimpo = CPF.ObterCPFSemFormatacao(cpfStr);

            //assert
            cpfLimpo.Digitos.Should().Be("01794200037");
        }


        [Fact(DisplayName = "Deve retornar um CPF com formatação XXX.XXX.XXX-XX")]
        [Trait("Value Object", "CPF")]
        public void deve_retornar_cpf_com_formatacao()
        {
            //arrage
            var cpfStr = "01794200037";
            var cpfStr2 = "1794200037";
            //act
            var cpfComMascara = CPF.ObterCPFComFormatacao(cpfStr);
            var cpfComMascara2 = CPF.ObterCPFComFormatacao(cpfStr2);
            //assert
            cpfComMascara.Digitos.Should().Be("017.942.000-37");
            cpfComMascara2.Digitos.Should().Be("017.942.000-37");
        }

        [Fact(DisplayName = "Deve garantir que dois cpfs com os mesmos digitos sejam o mesmo objeto")]
        [Trait("Value Object", "CPF")]
        public void deve_garantir_que_dois_cpfs_com_os_mesmos_digitos_sejam_o_mesmo_objeto()
        {
            //arrage
            var cpf1 = new CPF("1794200037");
            var cpf2 = new CPF("1794200037");

            //arrange
            var cpf1Mask = CPF.ObterCPFComFormatacao(cpf1.Digitos);
            var cpf2Mask = CPF.ObterCPFComFormatacao(cpf2.Digitos);

            //assert
            cpf1.Should().Be(cpf2);
            cpf1Mask.Should().Be(cpf1Mask);
        }

    }
}
