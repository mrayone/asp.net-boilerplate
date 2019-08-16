using IdentidadeAcesso.CrossCutting.Identity.Configuration;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Requeriment;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
                    services.AddScoped<IAuthorizationHandler, MyPermissaoPolicyHandler>();
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
            });
        }
    }

    public class MyPermissaoPolicyHandler : AuthorizationHandler<PermissaoPolicyRequeriment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoPolicyRequeriment requirement)
        {
            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
