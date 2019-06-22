using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class CriarPermissaoCommandHandler : CommandHandler, IRequestHandler<CriarPermissaoCommand, bool>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public CriarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository) : base(mediator, unitOfWork, notifications)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CriarPermissaoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);
                
            return await Task.FromResult(true);
        }
    }
}
