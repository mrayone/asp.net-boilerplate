using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class EmailSpec
    {

        [Fact(DisplayName = "Deve garantir que dois emails com o mesmo endereco sejam o mesmo objeto")]
        [Trait("Value Object", "Email")]
        public void deve_garantiar_que_dois_emails_com_mesmo_endereco_sejam_o_mesmo_objeto()
        {
            //arrange
            var email = new Email("maycon.rayone@gmail.com");
            var email2 = new Email("maycon.rayone@gmail.com");

            //act
            email.Should().Be(email2);
        }
    }
}
