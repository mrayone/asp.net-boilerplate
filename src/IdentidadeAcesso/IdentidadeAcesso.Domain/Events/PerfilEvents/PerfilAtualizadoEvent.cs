using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.PerfilEvents
{
    public class PerfilAtualizadoEvent : INotification
    {
        public PerfilAtualizadoEvent(Perfil perfil)
        {
            Perfil = perfil;
        }

        public Perfil Perfil { get; }
    }
}
