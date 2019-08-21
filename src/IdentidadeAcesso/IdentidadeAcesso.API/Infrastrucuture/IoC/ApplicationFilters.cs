using IdentidadeAcesso.CrossCutting.AspNetFilters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class ApplicationFilters
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped<ILogger<GlobalExceptionHandlerFilter>, 
                Logger<GlobalExceptionHandlerFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlerFilter>();
            services.AddScoped<GlobalActionLogger>();

            return services;
        }
    }
}
