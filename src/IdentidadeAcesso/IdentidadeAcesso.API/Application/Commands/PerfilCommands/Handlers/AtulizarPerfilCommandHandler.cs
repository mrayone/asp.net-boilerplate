﻿using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class AtulizarPerfilCommandHandler : CommandHandler, IRequestHandler<AtualizarPerfilCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtulizarPerfilCommandHandler(IMediator mediator, 
            IPerfilRepository perfilRepository, 
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications )
        {
            _mediator = mediator;
            _perfilRepository = perfilRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
        {
            if (!request.isValid())
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
