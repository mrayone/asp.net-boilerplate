using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.UsuarioCommandHandlers.Builder
{
    public class UsuarioBuilder
    {
        public static NovoUsuarioCommand ObterCommandFake()
        {
            return new NovoUsuarioCommand("Fake", "Sobrenome Fake", "F", "fake@gmail.com", "080.559.820-07", new DateTime(1993,7,22),
                "", "+5518981928663", true, "R São Paulo", "AZ848", null, "Centro", "784700000", "Cidade Fake", "SP");
        }
    }
}
