using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.PerfilEvents
{
    public class PerfilDeletadoEvent : INotification
    {
        public PerfilDeletadoEvent(Perfil perfil)
        {
            Perfil = perfil;
        }

        public Perfil Perfil { get; }
    }
}
