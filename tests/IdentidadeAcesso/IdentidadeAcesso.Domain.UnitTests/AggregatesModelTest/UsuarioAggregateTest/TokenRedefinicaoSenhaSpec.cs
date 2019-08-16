using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest
{
    public class TokenRedefinicaoSenhaSpec
    {
        [Fact(DisplayName = "Deve gerar token de redefinição de senha")]
        [Trait("Value Object", "Redefinir Senha")]
        public void Deve_gerar_token_de_redefinicao_de_senha()
        {
            //arrange
            var rs = new TokenRedefinicaoSenha("email@gmail.com", Guid.NewGuid());
            //act
            var token = rs.Token;
            //assert
            token.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve retornar true para token válido.")]
        [Trait("Value Object", "Redefinir Senha")]
        public void Deve_retornar_true_para_token_valido()
        {
            //arrange
            var rs = new TokenRedefinicaoSenha("email@gmail.com", Guid.NewGuid());

            //act
            var expirou = rs.TokenValido();

            //assert
            expirou.Should().BeTrue();
        }
    }
}