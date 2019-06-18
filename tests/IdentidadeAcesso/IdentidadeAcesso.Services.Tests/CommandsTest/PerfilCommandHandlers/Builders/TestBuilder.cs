using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PerfilCommandHandlers.Builders
{
    public class TestBuilder
    {
        public static Perfil PerfilFalso()
        {
            var identificacao = new Identificacao("Perfil RH 01", "Perfil de acesso nível 1");
            return new Perfil(Guid.NewGuid(), identificacao);
        }

        public static CriarPerfilCommand FalsoPerfilRequestComPermissoes()
        {
            return new CriarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "1",
                descricao: "a",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        },
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        },
                    }
                );
        }

        public static AtualizarPerfilCommand FalsoAtualizarPerfilRequestComPermissoes()
        {
            return new AtualizarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "1",
                descricao: "a",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        }
                    }
                );
        }

        public static CriarPerfilCommand FalsoAtualizarPerfilRequestComNomeExistente()
        {
            return new CriarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 01",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                     new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        }
                    }
                );
        }

        public static AtualizarPerfilCommand FalsoPerfilRequestComNomeExistente()
        {
            return new AtualizarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 01",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        }
                    }
                );
        }



        public static AtualizarPerfilCommand AtualizarPerfilFalsoRequestComPermissoes()
        {
            return new AtualizarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 01",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        }
                    }
                );
        }

        public static CriarPerfilCommand FalsoPerfilRequestOk()
        {
            return new CriarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 02",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        }
                    }
                );
        }

        public static AtualizarPerfilCommand AtualizarPerfilRequestOk()
        {
            return new AtualizarPerfilCommand(
                id: Guid.NewGuid(),
                nome: "Perfil RH 02",
                descricao: "Perfil de acesso nível 1",
                status: true,
                permissoesAssinadas: new List<PermissaoAssinadaDTO>()
                    {
                        new PermissaoAssinadaDTO()
                        {
                            PermissaoId = Guid.NewGuid()
                        }
                    }
                );
        }
    }
}
