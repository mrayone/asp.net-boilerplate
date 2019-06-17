using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class ExcluirPerfilCommandHandler : CommandHandler, IRequestHandler<ExcluirPerfilCommand, bool>
    {
        public ExcluirPerfilCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, 
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
        }

        public async Task<bool> Handle(ExcluirPerfilCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(false);
        }
    }
}
