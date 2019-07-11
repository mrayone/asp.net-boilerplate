using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Domain.Sevices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.DependencyInjection
{
    public static class DomainServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.TryAddScoped<IUsuarioService, UsuarioService>();
            services.TryAddScoped<IPerfilService, PerfilService>();
            services.TryAddScoped<IPermissaoService, PermissaoService>();

            return services;
        }
    }
}
