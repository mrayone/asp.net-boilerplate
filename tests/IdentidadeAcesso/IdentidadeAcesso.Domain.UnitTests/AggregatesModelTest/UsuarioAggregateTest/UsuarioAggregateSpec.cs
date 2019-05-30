using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.UnitTests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest
{
    public class UsuarioAggregateTest
    {
        
        [Fact(DisplayName = "Deve retornar estado inválido e erros")]
        [Trait("Raiz de Agregação", "Usuário")]
        public void deve_retornar_estado_invalido_e_erros()
        {
            //arrange
            var usuario = UsuarioBuilder.ObterUsuarioInvalido();
            var chaves = new List<string>()
            {
                "Nome",
                "Sexo",
                "Email",
                "CPF",
                "DataDeNascimento"
            };
            //act
            var valido = usuario.EhValido();

            //arrange
            valido.Should().BeFalse();
            usuario.Erros.Keys.Should().Contain(chaves);
        }
    }
}
