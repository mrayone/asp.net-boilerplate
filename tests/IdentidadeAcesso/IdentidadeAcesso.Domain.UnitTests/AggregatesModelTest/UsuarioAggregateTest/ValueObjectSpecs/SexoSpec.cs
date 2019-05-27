using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class SexoSpec
    {

        [Fact(DisplayName = "Deve ter estado invalido ao setar valores diferentes de 'Masculino' ou 'Feminino'")]
        [Trait("Value Object", "Sexo")]
        public void deve_ter_estado_invalido_se_setar_valor_diferente_de_dois_possiveis()
        {

            //arrange
            var sexo = new Sexo("M", "Mirosmar");

            //act

            //assert
            sexo.ValidationResult.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar erro quando um valor diferente do esperado.")]
        [Trait("Value Object", "Sexo")]
        public void deve_retornar_erro_quando_um_valor_eh_diferente_do_esperado()
        {

            //arrange
            var sexo = new Sexo("M", "Mirosmar");

            //act

            //assert
            sexo.ValidationResult.Erros.Should().Contain(new Dictionary<string, string>()
            {
                ["Valor Inválido"] = "O sexo deve ser definido como 'Masculino' ou 'Feminino'."
            });
        }


        [Fact(DisplayName = "Deve retornar verdadeiro para valores iguais")]
        [Trait("Value Object", "Sexo")]
        public void deve_retornar_verdadeiro_para_valores_iguais()
        {
            var fem = Sexo.Feminino;
            var mas = Sexo.Masculino;

            fem.Should().Be(Sexo.Feminino);
            mas.Should().Be(Sexo.Masculino);
        }

        [Fact(DisplayName = "Deve retornar verdadeiro para valores iguais quando setados manualmente.")]
        [Trait("Value Object", "Sexo")]
        public void deve_retornar_verdadeiro_para_valores_iguais_quando_setados_manualmente()
        {
            var fem = new Sexo("F", "Feminino");
            var mas = new Sexo("M", "Masculino");

            fem.Should().Be(Sexo.Feminino);
            mas.Should().Be(Sexo.Masculino);
        }

        [Fact(DisplayName = "Deve retornar erro se definido valores brancos")]
        [Trait("Value Object", "Sexo")]
        public void deve_retornar_erro_se_definido_valores_brancos()
        {
            var mas = new Sexo("", "");

            mas.ValidationResult.Erros.Should().HaveCount(1);
            mas.ValidationResult.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve lançar uma InvalidOperationException exception em caso de valor nulo.")]
        [Trait("Value Object", "Sexo")]
        public void deve_lancar_exception_se_definido_valores_nulo()
        {
            Action act = () => new Sexo(null, null);

            act.Should().Throw<NullReferenceException>();
        }
    }
}
