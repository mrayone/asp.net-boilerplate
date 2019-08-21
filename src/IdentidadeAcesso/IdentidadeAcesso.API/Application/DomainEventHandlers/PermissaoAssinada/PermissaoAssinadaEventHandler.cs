using IdentidadeAcesso.Domain.Events.PerfilEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.PermissaoAssinada
{
    public class PermissaoAssinadaHandler : INotificationHandler<PermissaoAssinadaEvent>
    {
        public async Task Handle(PermissaoAssinadaEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
