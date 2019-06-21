using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.PerfilEvents
{
    public class PermissaoCanceladaEvent : INotification
    {
        public PermissaoCanceladaEvent(Perfil perfil)
        {
            Perfil = perfil;
        }

        public Perfil Perfil { get; }
    }
}
