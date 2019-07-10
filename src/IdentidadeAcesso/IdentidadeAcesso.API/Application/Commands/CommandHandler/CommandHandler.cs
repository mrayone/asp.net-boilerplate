using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.CommandHandler
{
    public class BaseCommandHandler
    {
        readonly IMediator _mediator;
        readonly IUnitOfWork _unitOfWork;
        readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }

        protected async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) return await Task.FromResult(false);

            var result = await _unitOfWork.Commit();
            if (result.Success) return await Task.FromResult(true);

            await _mediator.Publish(new DomainNotification("Commit", "Ocorreu um erro ao persistir os dados."));

            return await Task.FromResult(false);
        }

        protected bool ValidarCommand(ICommand request)
        {
            if (!request.isValid())
            {
                NotificarErros(request);

                return false;
            }

            return true;
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
