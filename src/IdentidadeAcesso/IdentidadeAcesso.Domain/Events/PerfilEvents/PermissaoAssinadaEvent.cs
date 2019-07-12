using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.PerfilEvents
{
    public class PermissaoAssinadaEvent : INotification
    {
        public PermissaoAssinadaEvent(Perfil perfil)
        {
            Perfil = perfil;
        }

        public Perfil Perfil { get; }
    }
}
