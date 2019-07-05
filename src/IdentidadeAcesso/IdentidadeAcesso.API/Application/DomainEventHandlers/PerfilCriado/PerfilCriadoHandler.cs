using IdentidadeAcesso.Domain.Events.PerfilEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.PerfilCriado
{
    public class PerfilCriadoHandler : INotificationHandler<PerfilCriadoEvent>
    {
        public async Task Handle(PerfilCriadoEvent notification, CancellationToken cancellationToken)
        {
           
        }
    }
}
