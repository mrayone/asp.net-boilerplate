using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.PermissaoCriada
{
    public class PermissaoCriadaEventHandler : INotificationHandler<PermissaoCriadaEvent>
    {
        public async Task Handle(PermissaoCriadaEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
