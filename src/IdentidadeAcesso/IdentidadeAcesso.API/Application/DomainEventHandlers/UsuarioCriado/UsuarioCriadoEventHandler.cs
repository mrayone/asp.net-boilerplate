using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.DomainEventHandlers.UsuarioCriado
{
    public class UsuarioCriadoEventHandler : INotificationHandler<UsuarioCriadoEvent>
    {

        private IEmailSender _emailSender;

        public UsuarioCriadoEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(UsuarioCriadoEvent notification, CancellationToken cancellationToken)
        {
            //
            await _emailSender.SendEmailAsync(notification.Usuario.Email.Endereco, notification.Usuario.Nome.PrimeiroNome,
                "Usuário Criado", string.Format(@"<h4>Olá {0} tudo bem?</h4> 
                 <p>Seu usuário foi criado com sucesso!</p>
                 <p>Sua senha temporária é: <strong>{1}</strong></p>
                 <p><a href='http://localhost:4200/login'>Clique aqui</a></p><br><br>
                <p>Caso não esteja vendo o link acima clique neste link: http://localhost:4200/login </p>
                </p><br><br><p><strong>Atenciosamente</strong>, Knowledge Team</p>", notification.Usuario.Nome.PrimeiroNome, notification.Usuario.CPF.Digitos));
        }
    }
}
