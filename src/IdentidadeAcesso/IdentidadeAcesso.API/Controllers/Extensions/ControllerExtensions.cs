using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Controllers.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult NotificarDomainErros(this ControllerBase controller, IDomainNotificationHandler<DomainNotification> notifications)
        {

            if(notifications.HasNotifications())
            {
                return controller.BadRequest(new
                {
                    status = 404,
                    errors = notifications.GetNotifications().Select(n => n.Value)
                });
            }

            return controller.BadRequest();
        }
    }
}
