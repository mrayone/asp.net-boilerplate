using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using Knowledge.IO.Infra.Data.Context;
using Knowledge.IO.Infra.Data.Repository;
using Knowledge.IO.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class DataDependencies
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.TryAddScoped<IUsuarioRepository, UsuarioRepository>();
            services.TryAddScoped<IPerfilRepository, PerfilRepository>();
            services.TryAddScoped<IPermissaoRepository, PermissaoRepository>();
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<IdentidadeAcessoContext>(options =>
                   {
                       options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IdentidadeDb;Trusted_Connection=True;MultipleActiveResultSets=true",
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
                   },
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );

            return services;
        }
    }
}
