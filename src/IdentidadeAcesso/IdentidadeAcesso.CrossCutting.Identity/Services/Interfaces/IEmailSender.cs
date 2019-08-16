using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string destinatario, string subject, string message);
    }
}
