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
                return controller.Ok();
            }

            foreach (var item in result.Errors)
            {
                _notifications.GetNotifications().Add(new DomainNotification("", item));
            }

            return controller.BadRequest(_notifications.GetNotifications()
                        .Select(n => n.Value));
        }
    }
}
