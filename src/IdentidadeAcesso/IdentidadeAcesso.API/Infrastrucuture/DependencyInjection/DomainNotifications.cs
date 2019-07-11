using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.DependencyInjection
{
    public static class DomainNotifications
    {
        public static IServiceCollection AddDomainNotifications(this IServiceCollection services)
        {
            services.TryAddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            return services;
        }
    }
}
