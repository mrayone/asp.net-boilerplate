using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class EmailSpec
    {

        [Fact(DisplayName = "Deve retornar erro se valor não for um e-mail válido")]
        [Trait("Value Object", "Email")]
        public void deve_retornar_erro_se_valor_nao_for_email_valido()
        {
            //arrange
            var email = new Email("mariana.glogia.com");

            //act
            email.ValidationResult.Erros.Should().Contain(new List<string>()
            {
                "O email informado não é um válido."
            });
        }

        [Trait("Value Object", "Email")]
        [Theory(DisplayName = "Deve manter o estado válido 'false' para emails inválidos e 'true' para válidos")]
        [InlineData("maria.@gmail.com", true)]
        [InlineData("maria@gmail.com", true)]
        [InlineData("maria_2019@gmail.com", true)]
        [InlineData("maria_@gmail.com", true)]
        [InlineData("maycon.rayone@hotmail.com", true)]
        [InlineData("maycon.rayone@gmail.com", true)]
        [InlineData("maycon.rayonegmail.com", false)]
        [InlineData("js*@proseware.com", false)]
        [InlineData("js*@proseware..com", false)]
        [InlineData("-----------", false)]
        [InlineData("***asdad**..com", false)]
        public void deve_manter_o_estado_valido_false_se_invalido_e_true_se_valido(string endereco, bool isValid)
        {
            //arrange
            var email = new Email(endereco);

            //act
            email.ValidationResult.IsValid.Should().Be(isValid);
        }

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
