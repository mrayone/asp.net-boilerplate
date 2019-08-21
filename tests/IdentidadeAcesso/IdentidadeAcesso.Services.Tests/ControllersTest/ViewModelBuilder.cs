using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.UnitTests.ControllersTest
{
    public static class ViewModelBuilder
    {
        public static PermissaoViewModel PermissaoViewFake()
        {
            var list = new List<string>()
            {
                "Cadastrar",
                "Excluir",
                "Visualizar",
                "Editar"
            };
            var random = new Random();

            return new PermissaoViewModel()
            {
                Id = Guid.NewGuid(),
                Tipo = "Usuário",
                Valor = list[random.Next(0, 4)]
            };
        }

        internal static UsuarioViewModel UsuarioFake()
        {
            return new UsuarioViewModel()
            {
                Nome = "Fake",
                Sobrenome = "News",
                Sexo = "M",
                DataDeNascimento = new DateTime(1993,7, 22),
                Email = "email@gmail.com",
                Celular = "+5511999948663"
            };
        }

        internal static NovoUsuarioCommand UsuarioCommand()
        {
            return new NovoUsuarioCommand("Fake", "Sobrenome Fake", "F", "fake@gmail.com", "332.447.920-73", new DateTime(2002, 7, 22),
                null, "+5518981928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }

        internal static AtualizarUsuarioCommand AtualizarUsuarioCommand()
        {
            return new AtualizarUsuarioCommand(Guid.NewGuid(), "Fake", "Sobrenome Fake", "F", "fake@gmail.com", "332.447.920-73", new DateTime(2002, 7, 22),
                null, "+5518981928663", null, null, null, null, null, null, null, Guid.NewGuid());
        }
    }
}
