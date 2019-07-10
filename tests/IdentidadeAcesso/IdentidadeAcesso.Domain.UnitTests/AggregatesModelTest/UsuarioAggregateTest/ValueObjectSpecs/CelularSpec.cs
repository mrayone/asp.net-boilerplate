using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class CelularSpec
    {
        [Trait("Value Object", "Celular")]
        [Fact(DisplayName = "Deve garantir que dois celulares com o mesmo digito sejam o mesmo objeto")]
        public void deve_garantir_que_dois_telefones_com_mesmo_digito_sejam_o_mesmo_objeto()
        {
            var cel = new Celular("+5518981928663");
            var cel2 = new Celular("+5518981928663");

            cel.Should().Be(cel2);
        }

    }
}
