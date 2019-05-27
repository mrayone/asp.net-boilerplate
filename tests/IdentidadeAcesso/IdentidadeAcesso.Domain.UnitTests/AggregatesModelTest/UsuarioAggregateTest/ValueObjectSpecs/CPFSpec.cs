using FluentAssertions;
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

            var cpfNulo = new Dictionary<string, string>()
            {
                ["CPF Nulo"] = "O CPF não pode ser nulo."
            };

            var cpfBranco = new Dictionary<string, string>()
            {
                ["CPF Vazio"] = "O CPF não pode ser vazio.",
            };

            cpf.ValidationResult.Erros.Should().Contain(cpfNulo);
            cpf2.ValidationResult.Erros.Should().Contain(cpfBranco);
        }

        [Fact(DisplayName = "Deve retornar um CPF somente com os digitos se houver mascara")]
        [Trait("Value Object", "CPF")]
        public void deve_retornar_um_cpf_somente_com_digitos_se_houver_mascara()
        {
            //arrage
            var cpfStr = "017.942.000-37";
            var cpf = new CPF(cpfStr);
            //act
            var cpfLimpo = CPF.ObterCPFSemFormatacao(cpfStr);

            //assert
            cpfLimpo.Digitos.Should().Be("01794200037");
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
