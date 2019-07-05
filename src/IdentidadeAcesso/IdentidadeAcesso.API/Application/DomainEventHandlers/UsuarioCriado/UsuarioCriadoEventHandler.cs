using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.UsuarioCriado
{
    public class UsuarioCriadoEventHandler : INotificationHandler<UsuarioCriadoEvent>
    {
        public async Task Handle(UsuarioCriadoEvent notification, CancellationToken cancellationToken)
        {
            //
        }
    }
}
