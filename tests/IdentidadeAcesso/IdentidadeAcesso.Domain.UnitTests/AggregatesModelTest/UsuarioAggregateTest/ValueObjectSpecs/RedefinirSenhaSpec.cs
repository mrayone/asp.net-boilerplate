using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class RedefinirSenhaSpec
    {
        public RedefinirSenhaSpec()
        {

        }

        [Fact(DisplayName = "Deve gerar token de redefinição de senha")]
        [Trait("Value Object", "Redefinir Senha")]
        public void Deve_gerar_token_de_redefinicao_de_senha()
        {
            //arrange
            var rs = RedefinicaoSenha.GerarRedefinicaoDeSenha("maycon.rayone@gmail.com");
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
            var rs = RedefinicaoSenha.GerarRedefinicaoDeSenha("maycon.rayone@gmail.com");

            //act
            var expirou = RedefinicaoSenha.TokenValido(rs.Token);

            //assert
            expirou.Should().BeTrue();
        }


        [Fact(DisplayName = "Deve retornar false para token inválido.")]
        [Trait("Value Object", "Redefinir Senha")]
        public void Deve_retornar_false_para_token_invalido()
        {
            //arrange
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.AddDays(-2).ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            //act
            var expirou = RedefinicaoSenha.TokenValido(token);

            //assert
            expirou.Should().BeFalse();
        }
    }
}
