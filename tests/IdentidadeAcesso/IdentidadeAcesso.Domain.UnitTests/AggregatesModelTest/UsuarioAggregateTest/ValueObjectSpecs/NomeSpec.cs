using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class NomeSpec
    {
        private static string NOME = "Maycon Rayone";
        private static string SOBRENOME = "Rodrigues Xavier";
        public NomeSpec()
        { }

        [Fact(DisplayName = "A concatenação de primeiro nome e sobrenome devem formar o nome completo")]
        [Trait("Value Object", "Nome")]
        public void deve_retornar_o_nome_completo()
        {
            //arrange
            var nome = new Nome(NOME, SOBRENOME);

            //act
            var nomeCompleto = nome.ObterNomeCompleto();

            //assert
            nomeCompleto.Should().Be(NOME + " " + SOBRENOME);
        }

        [Fact(DisplayName = "O estado do nome deve ser invalido se valores em branco forem setados.")]
        [Trait("Value Object", "Nome")]
        public void o_estado_do_nome_deve_ser_invalido_se_valores_em_branco()
        {
            //arrange
            var nome = new Nome("", "");
            //act

            //assert
            nome.ValidationResult.Erros.Should().HaveCount(2);
            nome.ValidationResult.IsValid.Should().BeFalse();
            nome.ValidationResult.Erros.Should().Contain(new Dictionary<string, string>()
            {
                ["Primeiro Nome Vazio"] = "O primeiro nome não pode ser em branco.",
                ["Sobrenome Vazio"] = "O sobrenome não pode ser em branco."
            });
        }

        [Fact(DisplayName = "O estado do nome deve ser invalido se valores em branco forem setados.")]
        [Trait("Value Object", "Nome")]
        public void o_estado_do_nome_deve_ser_invalido_se_valores_nulos()
        {
            //arrange
            var nome = new Nome(null, null);
            //act

            //assert
            nome.ValidationResult.Erros.Should().HaveCount(2);
            nome.ValidationResult.IsValid.Should().BeFalse();
            nome.ValidationResult.Erros.Should().Contain(new Dictionary<string, string>()
            {
                ["Primeiro Nome Nulo"] = "O primeiro nome não pode ser nulo.",
                ["Sobrenome Nulo"] = "O sobrenome não pode ser nulo."
            });
        }


        [Fact(DisplayName = "O estado do nome deve ser valido")]
        [Trait("Value Object", "Nome")]
        public void o_estado_do_nome_deve_ser_valido()
        {
            //arrange
            var nome = new Nome(NOME, SOBRENOME);
            //act

            //assert
            nome.ValidationResult.Erros.Should().HaveCount(0);
            nome.ValidationResult.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Objetos de valores devem ser iguais quando possuem os mesmos dados")]
        [Trait("Value Object", "Nome")]
        public void deve_ser_verdadeiro_para_duas_instancias_com_os_mesmos_dados()
        {
            //arrange
            var nome = new Nome(NOME, SOBRENOME);
            var nome2 = new Nome(NOME, SOBRENOME);
            //act

            //assert
            nome.GetHashCode().Should().Be(nome2.GetHashCode());
            nome.Should().Be(nome2);
        }
    }
}
