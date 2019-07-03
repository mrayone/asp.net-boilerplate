using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers.Builder
{
    public class UsuarioBuilder
    {
        public static NovoUsuarioCommand ObterCommandFake()
        {
            return new NovoUsuarioCommand("Fake", "Sobrenome Fake", "F", "fake@gmail.com", "080.559.820-07", new DateTime(2002,7,22),
                null, "+5518981928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }

        public static NovoUsuarioCommand ObterCommandFakeErroDeDomain()
        {
            return new NovoUsuarioCommand("Fake", "Sobrenome Fake", "F", "fake@gmail.com", "082.559.820-07", new DateTime(2002, 7, 22),
                null, "18981928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }

        public static Usuario UsuarioFake()
        {
            var nome = new NomeCompleto("Fake", "Sobrenome");
            var email = new Email("fake@gmail.com");
            var sexo = Sexo.Masculino;
            var cpf = new CPF("080.559.820-07");
            var dataDeNascimento = new DataDeNascimento(new DateTime(2002, 7, 22));
            return new Usuario(nome, sexo, email, cpf, dataDeNascimento, Guid.NewGuid());
        }
    }
}
