using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            //TODO: Implementar Domain Evento.
        }

        public bool HasNotifications()
        {
            _notifications = new List<DomainNotification>() ?? _notifications;
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
