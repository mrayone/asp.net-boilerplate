using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
