using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class ApplicationNotifications
    {
        public static IServiceCollection AddApplicationNotifications(this IServiceCollection services)
        {

            return services;
        }
    }
}
