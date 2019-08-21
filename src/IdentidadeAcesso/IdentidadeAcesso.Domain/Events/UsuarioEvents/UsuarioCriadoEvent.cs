using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.UsuarioEvents
{
    public class UsuarioCriadoEvent : INotification
    {
        public UsuarioCriadoEvent(Usuario usuario)
        {
            Usuario = usuario;
        }

        public Usuario Usuario { get; private set; }
    }
}
