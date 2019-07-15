using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.SeedOfWork;
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
        public static IActionResult VerificarErros(this ControllerBase controller, INotificationHandler<DomainNotification> notifications, CommandResponse result)
        {
            var _notifications = (DomainNotificationHandler) notifications;
            if (result.Success)
            {
                if (_notifications.HasNotifications())
                {
                    return controller.BadRequest(_notifications.GetNotifications()
                        .Select(n => n.Value));
                }

                return controller.Ok();
            }

            return controller.BadRequest(result.Errors);
        }
    }
}
