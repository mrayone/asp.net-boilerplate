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
            await _emailSender.SendEmailAsync(notification.Email, notification.Nome,
                "Redefinição de senha", string.Format(@"<h4>Olá {0} tudo bem?</h4> <p>Você solicitou uma redefinição de senha, por favor clique no link abaixo
                 <p><a href='http://localhost:4200/trocar-senha/{1}'>Clique aqui</a></p><br><br>
                <p>Caso não esteja vendo o link acima clique neste link: http://localhost:4200/trocar-senha/{1} </p>
                </p><br><br><p><strong>Atenciosamente</strong>, Knowledge Team</p>", notification.Nome, notification.Token));
        }
    }
}
