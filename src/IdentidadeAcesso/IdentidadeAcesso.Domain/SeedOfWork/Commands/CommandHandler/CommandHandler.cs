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
        IMediator _mediator;
        IUnitOfWork _unitOfWork;

        public CommandHandler(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
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
