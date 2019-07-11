using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class NomeCompletoSpec
    {
        private static string NOME = "Maycon Rayone";
        private static string SOBRENOME = "Rodrigues Xavier";
        public NomeCompletoSpec()
        { }

        [Fact(DisplayName = "Deve retornar a concatenação do primeiro nome e sobrenome.")]
        [Trait("Value Object", "Nome")]
        public void Deve_Retornar_a_Concatenacao_do_PrimeiroNome_e_Sobrenome()
        {
            //arrange
            var nome = new NomeCompleto(NOME, SOBRENOME);

            //act
            var nomeCompleto = nome.ObterNomeCompleto();

            //assert
            nomeCompleto.Should().Be(NOME + " " + SOBRENOME);
        }

        [Fact(DisplayName = "Objetos de valores devem ser iguais quando possuem os mesmos dados")]
        [Trait("Value Object", "Nome")]
        public void deve_ser_verdadeiro_para_duas_instancias_com_os_mesmos_dados()
        {
            //arrange
            var nome = new NomeCompleto(NOME, SOBRENOME);
            var nome2 = new NomeCompleto(NOME, SOBRENOME);
            //act

            //assert
            nome.GetHashCode().Should().Be(nome2.GetHashCode());
            nome.Should().Be(nome2);
        }
    }
}
