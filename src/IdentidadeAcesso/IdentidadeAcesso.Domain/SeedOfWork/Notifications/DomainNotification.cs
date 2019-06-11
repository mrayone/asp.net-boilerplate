using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.Notifications
{
    public class DomainNotification : INotification
    {
        public Guid NotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            NotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }

    }
}
