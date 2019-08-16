using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
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
        public async Task SendEmailAsync(string email, string destinatario, string subject, string message)
        {
            var apiKey = "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";
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
