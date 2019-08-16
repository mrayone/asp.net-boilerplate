using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Services
{
    public class MessageService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //TODO: implementar com sendgrid.
        }
    }
}
