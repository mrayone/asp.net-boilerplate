using Knowledge.IO.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
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

                });

            });

        }
    }
}
