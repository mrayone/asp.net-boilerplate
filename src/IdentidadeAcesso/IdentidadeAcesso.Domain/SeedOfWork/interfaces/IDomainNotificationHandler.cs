using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.Interfaces
{
    public interface IDomainNotificationHandler<T> : IDisposable, INotificationHandler<T> where T : INotification
    {
        List<T> GetNotifications();
        bool HasNotifications();
    }
}
