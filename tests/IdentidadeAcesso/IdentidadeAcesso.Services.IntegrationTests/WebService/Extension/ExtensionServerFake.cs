using Knowledge.IO.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.IntegrationTests.WebService.Extension
{
    public static class ExtensionServerFake
    {
        public static WebApplicationFactory<TStartup> ComNovoDb<TStartup>(this WebApplicationFactory<TStartup> factory) where TStartup : class
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices( services =>
                {
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
            });
        }
    }
}
