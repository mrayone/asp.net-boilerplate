using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.SeedOfWorkTest.ValueObjectSpecs
{
    public class StatusSpec
    {

        [Fact(DisplayName = "Deve retornar verdadeiro para valores iguais")]
        [Trait("Value Object", "Status")]
        public void deve_retornar_verdadeiro_para_valores_iguais()
        {
            var ativo = Status.Ativo;
            var inativo = Status.Inativo;

            inativo.Should().Be(Status.Inativo);
            ativo.Should().Be(Status.Ativo);

            ativo.ValidationResult.IsValid.Should().BeTrue();
            inativo.ValidationResult.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve validar se valores são diferentes")]
        [Trait("Value Object", "Status")]
        public void deve_validar_se_valores_sao_diferentes()
        {
            var ativo = Status.Ativo;
            var inativo = Status.Inativo;

            inativo.Should().NotBe(ativo);
        }

    }
}
