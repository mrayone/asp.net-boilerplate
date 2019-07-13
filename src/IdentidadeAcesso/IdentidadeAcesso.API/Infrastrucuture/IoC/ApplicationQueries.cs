using IdentidadeAcesso.API.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class ApplicationQueries
    {
        public static IServiceCollection AddApplicationQueries(this IServiceCollection services)
        {
            services.TryAddScoped<IPermissaoQueries, PermissaoQueries>();
            services.TryAddScoped<IPerfilQueries, PerfilQueries>();

            return services;
        }
    }
}
