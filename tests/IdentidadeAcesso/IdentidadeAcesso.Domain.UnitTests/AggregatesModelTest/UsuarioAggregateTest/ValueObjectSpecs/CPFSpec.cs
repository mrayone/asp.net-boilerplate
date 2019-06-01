﻿using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
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

        [Fact(DisplayName = "Deve ter seu estado inválido para cpf em branco ou nulo")]
        [Trait("Value Object", "CPF")]
        public void deve_ter_seu_estado_invalido_para_cpf_em_branco_ou_nulo()
        {
            //arrange
            var cpf = new CPF(null);
            var cpf2 = new CPF("");


            //act

            //assert
            cpf.ValidationResult.IsValid.Should().BeFalse();
            cpf.ValidationResult.IsValid.Should().BeFalse();

        }

        [Fact(DisplayName = "Deve retornar erro para cpf em branco ou nulo")]
        [Trait("Value Object", "CPF")]
        public void deve_retornar_errro_para_cpf_em_branco_ou_nulo()
        {
            var cpf = new CPF(null);
            var cpf2 = new CPF("");

            var cpfNuloBranco = new Dictionary<string, string>()
            {
                ["CPF Nulo/Vazio"] =  "O CPF deve ser fornecido."
            };

            cpf.ValidationResult.Erros.Should().Contain(cpfNuloBranco);
            cpf2.ValidationResult.Erros.Should().Contain(cpfNuloBranco);
        }

        [Fact(DisplayName = "Deve retornar erro se CPF ultrapassar onze dígitos")]
        [Trait("Value Object", "CPF")]
        public void deve_retornar_erro_se_cpf_ultrapassar_onze_digitos()
        {
            var cpf = new CPF("1111.111.111-55");
            var cpf2 = new CPF("111111111155");

            var cpfErro = new Dictionary<string, string>()
            {
                ["CPF Excedeu Digitos"] = "O CPF não pode possuir mais de 11 digitos."
            };

            cpf.ValidationResult.Erros.Should().Contain(cpfErro);
            cpf2.ValidationResult.Erros.Should().Contain(cpfErro);
        }

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


        [Fact(DisplayName = "Deve retornar erro se CPF for inválido")]
        [Trait("Value Object", "CPF")]
        public void deve_retornar_erro_se_cpf_for_invalido()
        {
            var cpf = new CPF("111.111.111-55");

            var cpfErro = new Dictionary<string, string>()
            {
                ["CPF Inválido"] = "O CPF informado é inválido."
            };

            cpf.ValidationResult.Erros.Should().Contain(cpfErro);
        }

        [Trait("Value Object", "CPF")]
        [Theory(DisplayName = "Deve validar CPF(s) com e sem mascara")]
        [InlineData("017.942.000-37", true)]
        [InlineData("17.942.000-37", true)]
        [InlineData("1794200037", true)]
        [InlineData("041.442.300-37", false)]
        [InlineData("04144230037", false)]
        public void deve_validar_cpfs_com_e_sem_mascara(string cpfStr, bool isValid)
        {
            var cpf = new CPF(cpfStr);
            //act

            //assert
            cpf.ValidationResult.IsValid.Should().Be(isValid);
        }
    }
}
