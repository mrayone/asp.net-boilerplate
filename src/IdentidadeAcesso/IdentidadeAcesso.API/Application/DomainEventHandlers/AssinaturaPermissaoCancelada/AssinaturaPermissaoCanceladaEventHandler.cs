using IdentidadeAcesso.Domain.Events.PerfilEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.AssinaturaPermissaoCancelada
{
    public class AssinaturaPermissaoCanceladaEventHandler : INotificationHandler<AssinaturaPermissaoCanceladaEvent>
    {
        public async Task Handle(AssinaturaPermissaoCanceladaEvent notification, CancellationToken cancellationToken)
        {
            //Implementar
        }
    }
}
