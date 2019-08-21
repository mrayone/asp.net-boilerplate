using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.API.Application.DomainEventHandlers.NovaSenhaSolicitada;
using IdentidadeAcesso.API.Application.DomainEventHandlers.UsuarioCriado;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class DomainNotifications
    {
        public static IServiceCollection AddDomainNotifications(this IServiceCollection services)
        {
            services.TryAddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.TryAddScoped<INotificationHandler<NovaSenhaSolicitadaEvent>, NovaSenhaSolicitadaEventHandler>();
            services.TryAddScoped<INotificationHandler<UsuarioCriadoEvent>, UsuarioCriadoEventHandler>();

            return services;
        }
    }
}
