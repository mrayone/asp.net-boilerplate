using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler
{
    public class CommandHandler
    {
        readonly IMediator _mediator;
        readonly IUnitOfWork _unitOfWork;
        readonly DomainNotificationHandler _notifications;

        public CommandHandler(IMediator mediator, IUnitOfWork unitOfWork, 
            INotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            if (_unitOfWork.Commit().Success) return true;

            _mediator.Publish(new DomainNotification("Commit", "Ocorreu um erro ao persistir os dados."));

            return false;
        }

        protected void NotificarErros(ICommand request)
        {
            foreach (var item in request.ValidationResult.Errors)
            {
                _mediator.Publish(new DomainNotification(request.GetType().Name, item.ErrorMessage));
            }
        }

    }
}
