using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Queries;
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

        public static PermissaoAssinadaDTO PermissaoAssinadaFake()
        {
            return new PermissaoAssinadaDTO()
            {
                PerfilId = Guid.NewGuid(),
                PermissaoId = Guid.NewGuid(),
                Status = true
            };
        }
    }
}
