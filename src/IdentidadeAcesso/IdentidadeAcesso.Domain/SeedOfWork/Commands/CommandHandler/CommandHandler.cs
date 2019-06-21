using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> Commit()
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

        protected bool ValidarEntity(Entity entity)
        {
            if (!entity.EhValido())
            {
                NotificarErros(entity);

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

        protected void NotificarErros(Entity entity)
        {
            foreach (var item in entity.Erros)
            {
                _mediator.Publish(new DomainNotification(item.Property, item.MessageError));
            }
        }

    }
}
