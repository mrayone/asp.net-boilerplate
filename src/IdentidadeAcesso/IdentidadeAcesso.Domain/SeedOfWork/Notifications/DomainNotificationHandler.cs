using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            
            //TODO: Implementar Domain Evento.
        }
    }
}
