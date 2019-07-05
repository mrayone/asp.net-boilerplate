using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.UsuarioAtualizado
{
    public class UsuarioAtualizadoEventHandler : INotificationHandler<UsuarioAtualizadoEvent>
    {
        public async Task Handle(UsuarioAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
