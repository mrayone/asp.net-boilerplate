using IdentidadeAcesso.CrossCutting.Identity.Options;
using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Services
{
    public class MessageService : IEmailSender
    {
        private readonly IOptionsMonitor<AppOptions> _options;

        public MessageService(IOptionsMonitor<AppOptions> options)
        {
            _options = options;
        }
        public async Task SendEmailAsync(string email, string destinatario, string subject, string message)
        {
            var apiKey = _options.CurrentValue.SendGridKey;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@knowledge.io", "Knowledge Team"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email, destinatario));
            var response = await client.SendEmailAsync(msg);

        }
    }
}
