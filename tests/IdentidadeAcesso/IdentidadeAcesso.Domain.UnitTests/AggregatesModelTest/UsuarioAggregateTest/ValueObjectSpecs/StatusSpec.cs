using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class StatusSpec
    {
        [Fact(DisplayName = "Deve ter estado invalido ao setar valores diferentes de 'Ativo' ou 'Inativo'")]
        [Trait("Value Object", "Status")]
        public void deve_ter_estado_invalido_se_setar_valor_diferente_de_dois_possiveis()
        {

            //arrange
            var status = new Status("A", "Akieio");

            //act

            //assert
            status.ValidationResult.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar erro quando um valor diferente do esperado.")]
        [Trait("Value Object", "Status")]
        public void deve_retornar_erro_quando_um_valor_eh_diferente_do_esperado()
        {

            //arrange
            var status = new Status("M", "Mirosmar");

            //act

            //assert
            status.ValidationResult.Erros.Should().Contain(new Dictionary<string, string>()
            {
                ["Status Inválido"] = "O status só pode ser definido como 'Ativo' ou 'Inativo'."
            });
        }


        [Fact(DisplayName = "Deve retornar verdadeiro para valores iguais")]
        [Trait("Value Object", "Status")]
        public void deve_retornar_verdadeiro_para_valores_iguais()
        {
            var ativo = Status.Ativo;
            var inativo = Status.Inativo;

            inativo.Should().Be(Status.Inativo);
            ativo.Should().Be(Status.Ativo);
        }

        [Fact(DisplayName = "Deve retornar verdadeiro para valores iguais quando setados manualmente.")]
        [Trait("Value Object", "Status")]
        public void deve_retornar_verdadeiro_para_valores_iguais_quando_setados_manualmente()
        {
            var ativo = new Status("A", "Ativo");
            var inativo = new Status("I", "Inativo");

            inativo.Should().Be(Status.Inativo);
            ativo.Should().Be(Status.Ativo);
        }

        [Fact(DisplayName = "Deve retornar erro se definido valores brancos")]
        [Trait("Value Object", "Status")]
        public void deve_retornar_erro_se_definido_valores_brancos()
        {
            var status = new Status("", "");

            status.ValidationResult.Erros.Should().HaveCount(1);
            status.ValidationResult.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve lançar uma InvalidOperationException exception em caso de valor nulo.")]
        [Trait("Value Object", "Status")]
        public void deve_lancar_exception_se_definido_valores_nulo()
        {
            Action act = () => new Status(null, null);

            act.Should().Throw<NullReferenceException>();
        }
    }
}
