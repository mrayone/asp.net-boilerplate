using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.IntegrationTests.WebService
{
    public class WebServiceCustomizadoFactory<TStartup> 
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => 
            {
                // criando um novo provedor de serviços
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

                services.AddDbContext<IdentidadeAcessoDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                //Build the service provider
                var sp = services.BuildServiceProvider();


                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<IdentidadeAcessoDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<WebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
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
    }

    internal class Utilities
    {
        internal static void InitializeDbForTests(IdentidadeAcessoDbContext db)
        {
            db.Permissoes.AddRange(obterPermissoes());



            db.SaveChangesAsync();
        }

        private static List<Permissao> obterPermissoes()
        {
            return new List<Permissao>()
            {
                Permissao.PermissaoFactory.CriarPermissao(new Guid("7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4"), "Usuário", "Cadastrar"),
                Permissao.PermissaoFactory.CriarPermissao(null, "Usuário", "Remover"),
                Permissao.PermissaoFactory.CriarPermissao(null, "Usuário", "Visualizar Cadastro"),
            };
        }
    }
}
