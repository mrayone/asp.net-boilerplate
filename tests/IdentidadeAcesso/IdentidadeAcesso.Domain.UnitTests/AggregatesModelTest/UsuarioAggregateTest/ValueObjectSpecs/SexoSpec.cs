using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class SexoSpec
    {

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
