using IdentidadeAcesso.API.Options;
using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.NovaSenhaSolicitada
{
    public class NovaSenhaSolicitadaEventHandler : INotificationHandler<NovaSenhaSolicitadaEvent>
    {
        private readonly IEmailSender _emailSender;
        private readonly IOptionsMonitor<UrlOptions> _options;

        public NovaSenhaSolicitadaEventHandler(IEmailSender emailSender, IOptionsMonitor<UrlOptions> options)
        {
            _emailSender = emailSender;
            _options = options;
        }

        public async Task Handle(NovaSenhaSolicitadaEvent notification, CancellationToken cancellationToken)
        {
            var url = _options.CurrentValue.UrlSpa;
            var urlFormat = string.Format(url + "/redefinir-senha/{0}", notification.Token);
            //TODO: enviar e-mail.
            await _emailSender.SendEmailAsync(notification.Email, notification.Nome,
                "Redefinição de senha", string.Format(@"<h4>Olá {0} tudo bem?</h4> <p>Você solicitou uma redefinição de senha, por favor clique no link abaixo
                 <p><a href='{1}'>Clique aqui</a></p><br><br>
                <p>Caso não esteja vendo o link acima clique neste link: <a href='{1}'>{1}</a> </p>
                </p><br><br><p><strong>Atenciosamente</strong>, Knowledge Team</p>", notification.Nome, urlFormat));
        }
    }
}
