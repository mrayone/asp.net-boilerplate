using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class SexoSpec
    {
        [Fact(DisplayName = "Deve validar o estado do sexo.")]
        [Trait("Value Object", "Sexo")]
        public void deve_validar_estado_do_sexo()
        {
            var sexo = SexoBuilder.ObterSexoInvalido();

            //act
            var isValid = sexo.EhValido();

            isValid.Should().BeFalse();
            sexo.ValidationResult.Erros.Should().Contain(new List<string>()
            {
                "O sexo deve ser definido como 'Masculino' ou 'Feminino'."
            });
        }

        [Fact(DisplayName = "Deve retornar verdadeiro para valores iguais")]
        [Trait("Value Object", "Sexo")]
        public void deve_retornar_verdadeiro_para_valores_iguais()
        {
            var fem = Sexo.Feminino;
            var mas = Sexo.Masculino;


            fem.ValidationResult.IsValid.Should().BeTrue();
            mas.ValidationResult.IsValid.Should().BeTrue();

            fem.Should().Be(Sexo.Feminino);
            mas.Should().Be(Sexo.Masculino);
        }

        [Fact(DisplayName = "Deve validar se valores são diferentes")]
        [Trait("Value Object", "Sexo")]
        public void deve_validar_se_valores_sao_diferentes()
        {
            var mas = Sexo.Masculino;
            var fem = Sexo.Feminino;

            mas.Should().NotBe(fem);
        }
    }
}
