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
            return new NovoUsuarioCommand("Fake", "Sobrenome Fake", "F", "fake@gmail.com", "332.447.920-73", new DateTime(2002,7,22),
                null, "+5518981928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }

        public static NovoUsuarioCommand ObterCommandInvalidoFake()
        {
            return new NovoUsuarioCommand("Fake", "Sobrenome Fake", "F", "fakegmail.com", "354.447.920-73", new DateTime(2002, 7, 22),
                null, "+55181928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }


        public static AtualizarUsuarioCommand ObterCommandFakeAtualizar()
        {
            return new AtualizarUsuarioCommand(Guid.NewGuid(),"Fake", "Sobrenome Fake", "F", "fake@gmail.com", "332.447.920-73", new DateTime(2002, 7, 22),
                null, "+5518981928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }

        public static ExcluirUsuarioCommand ObterCommandFakeExcluir()
        {
            return new ExcluirUsuarioCommand(Guid.NewGuid());
        }

        public static ExcluirUsuarioCommand ObterCommandFakeExcluirInvalido()
        {
            return new ExcluirUsuarioCommand(Guid.Empty);
        }

        public static AtualizarUsuarioCommand ObterCommandFakeAtualizarErroDeDomain()
        {
            return new AtualizarUsuarioCommand(Guid.NewGuid(), "Fake", "Sobrenome Fake", "F", "fake@gmail.com", "082.559.820-07", new DateTime(2002, 7, 22),
                null, "18981928663", null, null, null, null, null, null, null, Guid.NewGuid());
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
            var cpf = new CPF("332.447.920-73");
            var dataDeNascimento = new DataDeNascimento(new DateTime(2002, 7, 22));
            return new Usuario(nome, sexo, email, cpf, dataDeNascimento);
        }
    }
}
