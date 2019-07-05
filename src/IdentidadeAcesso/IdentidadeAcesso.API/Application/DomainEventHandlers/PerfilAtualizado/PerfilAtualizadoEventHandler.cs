using IdentidadeAcesso.Domain.Events.PerfilEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.PerfilAtualizado
{
    public class PerfilAtualizadoEventHandler : INotificationHandler<PerfilAtualizadoEvent>
    {
        public async Task Handle(PerfilAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
