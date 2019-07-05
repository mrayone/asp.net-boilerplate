using IdentidadeAcesso.Domain.Events.PerfilEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.PermissaoCancelada
{
    public class PermissaoCanceladaEventHandler : INotificationHandler<PermissaoCanceladaEvent>
    {
        public async Task Handle(PermissaoCanceladaEvent notification, CancellationToken cancellationToken)
        {
            //Implementar
        }
    }
}
