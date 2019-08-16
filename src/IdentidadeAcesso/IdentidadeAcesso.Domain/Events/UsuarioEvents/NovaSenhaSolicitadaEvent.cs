using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.Events.UsuarioEvents
{
    public class NovaSenhaSolicitadaEvent : INotification
    {
        public NovaSenhaSolicitadaEvent(string nome, string email, string token)
        {
            Nome = nome;
            Email = email;
            Token = token;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Token { get; }
    }
}
