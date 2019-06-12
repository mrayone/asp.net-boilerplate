using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            //TODO: Implementar Domain Evento.

            return Task.CompletedTask;
        }

        public bool HasNotifications()
        {
            _notifications = new List<DomainNotification>() ?? _notifications;
            return _notifications.Any();
        }
    }
}
