using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.NovaSenhaSolicitada
{
    public class NovaSenhaSolicitadaEventHandler : INotificationHandler<NovaSenhaSolicitadaEvent>
    {
        private IEmailSender _emailSender;

        public NovaSenhaSolicitadaEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(NovaSenhaSolicitadaEvent notification, CancellationToken cancellationToken)
        {
            //TODO: enviar e-mail.
            await _emailSender.SendEmailAsync(notification.Usuario.Email.Endereco,
                "Redefinição de senha", string.Format(@"Olá {0} tudo bem? Você solicitou a redefinição de senha, por favor clique no link
                 http://localhost:5001/trocarsenha?auth={1}", notification.Usuario.Nome.PrimeiroNome, notification.Usuario.RedefinicaoSenha.Token));
        }
    }
}
