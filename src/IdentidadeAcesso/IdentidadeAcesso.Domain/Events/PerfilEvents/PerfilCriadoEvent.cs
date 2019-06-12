using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.PerfilEvents
{
    public class PerfilCriadoEvent : INotification
    {
        public PerfilCriadoEvent(Perfil perfil)
        {
            Perfil = perfil;
        }

        public Perfil Perfil { get; }



    }
}
