using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class SenhaSpec
    {

        public SenhaSpec()
        {
        }

        [Fact( DisplayName = "Deve gerar hash para senha fornecida.")]
        [Trait("Value Objects"," Senha")]
        public void Deve_GerarHash_Para_Senha_Fornecida()
        {
            //arrange
            var senha = "123456";
           
            //act
            var senhaHash =  Senha.GerarSenha("123456");

            //assert
            senhaHash.ValidarSenha(senha).Should().BeTrue();
        }

        [Fact(DisplayName = "Deve gerar senhas diferentes e retornar false.")]
        [Trait("Value Objects", " Senha")]
        public void Deve_Comparar_Senhas_Diferentes_E_RetornarFalse()
        {
            //arrange
            var senha = "12345";

            //act
            var senhaHash = Senha.GerarSenha("123456");
            var senhaHash2 = Senha.GerarSenha("123456");

            //assert
            senhaHash.ValidarSenha(senha).Should().BeFalse();
            senhaHash2.Should().NotBe(senhaHash);
        }
    }
}
