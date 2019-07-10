using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class TelefoneSpec
    {
        [Trait("Value Object", "Telefone")]
        [Fact(DisplayName = "Deve garantir que dois telefones com o mesmo digito sejam o mesmo objeto")]
        public void deve_garantir_que_dois_telefones_com_mesmo_digito_sejam_o_mesmo_objeto()
        {
            var telefone = new Telefone("+551832815597");
            var telefone2 = new Telefone("+551832815597");

            telefone.Should().Be(telefone2);
        }
    }
}
