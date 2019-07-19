using Dapper;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.Services.IntegrationTests.WebService
{
    public class WebServiceCustomizadoFactory<TStartup> 
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        private SqliteConnection sqlite;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => 
            {
                // criando um novo provedor de serviços
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();
                
                sqlite = new SqliteConnection("DataSource=:memory:");
                sqlite.Open();
                services.AddDbContext<IdentidadeAcessoDbContext>(options =>
                {
                    options.UseSqlite(sqlite).EnableSensitiveDataLogging();
                    options.UseInternalServiceProvider(serviceProvider);
                });

                //Build the service provider
                var sp = services.BuildServiceProvider();
                SqlMapper.AddTypeHandler<Guid>(new GuidTypeHandler());

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<IdentidadeAcessoDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<WebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Um erro correu ao iniciar db " +
                            $"database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    internal class Utilities
    {
        internal static async void InitializeDbForTests(IdentidadeAcessoDbContext db)
        {
            db.Permissoes.AddRange(ObterPermissoes());
            db.Perfis.AddRange(ObterPerfis());
            db.Usuarios.AddRange(ObterUsuarios());
            await db.SaveChangesAsync();
        }

        private static List<Permissao> ObterPermissoes()
        {
            var list = new List<Permissao>()
            {
                Permissao.PermissaoFactory.CriarPermissao(new Guid("7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4"), "Usuário", "Cadastrar"),
                Permissao.PermissaoFactory.CriarPermissao(new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), "Usuário", "Remover"),
                Permissao.PermissaoFactory.CriarPermissao(null, "Usuário", "Visualizar Cadastro"),
            };

            return list;
        }

        private static List<Usuario> ObterUsuarios()
        {
            var list = new List<Usuario>()
            {
                Usuario.UsuarioFactory.CriarUsuario(null, "Fake", "Fake L", "M", "fakedoi_2@gmail.com", "28999953084",
                new DateTime(1993,7,22), "+5518981928363",
                new Endereco("R Tal", "19ew", "Centro", "18971000", "Seilandia",
                "Seilão"), Guid.Parse("8cd6c8ca-7db7-4551-b6c5-f7a724286709")),
            };

            return list;
        }

        private static List<Perfil> ObterPerfis()
        {
            var list = new List<Perfil>()
            {
                Perfil.PerfilFactory
                .NovoPerfil(new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), "Administração", "Perfil que possui os maiores níveis de acesso"),
                Perfil.PerfilFactory
                .NovoPerfil(new Guid("c5ecd8a8-f086-4058-b205-a561603415f9"), "Recursos Humanos 1", "Perfil que possui alguns níveis de RH."),
                Perfil.PerfilFactory
                .NovoPerfil(null, "Recursos Humanos 2", "Perfil que possui alguns níveis de RH.")
            };
            return list;
        }
    }

    #region GuidTypeHandler
    public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override Guid Parse(object value)
        {
            var inVal = (byte[])value;
            byte[] outVal = new byte[] { inVal[0], inVal[1], inVal[2], inVal[3], inVal[4], inVal[5], inVal[6], inVal[7], inVal[8], inVal[9], inVal[10], inVal[11], inVal[12], inVal[13], inVal[14], inVal[15] };
            return new Guid(outVal);
        }

        public override void SetValue(System.Data.IDbDataParameter parameter, Guid value)
        {
            var inVal = value.ToByteArray();
            byte[] outVal = new byte[] { inVal[0], inVal[1], inVal[2], inVal[3], inVal[4], inVal[5], inVal[6], inVal[7], inVal[8], inVal[9], inVal[10], inVal[11], inVal[12], inVal[13], inVal[14], inVal[15] };
            parameter.Value = outVal;
        }
    }
    #endregion
}
