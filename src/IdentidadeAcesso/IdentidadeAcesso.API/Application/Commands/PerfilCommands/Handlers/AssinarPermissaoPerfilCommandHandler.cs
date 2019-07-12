using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class AssinarPermissaoPerfilCommandHandler : BaseCommandHandler, IRequestHandler<AssinarPermissaoPerfilCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilService _perfilService;
        private readonly IPerfilRepository _perfilRepository;

        public AssinarPermissaoPerfilCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications, IPerfilService domainService,
            IPerfilRepository perfilRespository) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilService = domainService;
            _perfilRepository = perfilRespository;
        }

        public async Task<bool> Handle(AssinarPermissaoPerfilCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            if (!await this.BuscarPerfil(request.PerfilId, _perfilRepository))
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Perfil não encontrado."));
                return await Task.FromResult(false);
            }

            var perfil = await _perfilService.CancelarPermissoesAsync(request.PermissaoId, request.PerfilId);

            if (await Commit())
            {
                await _mediator.Publish(new PermissaoAssinadaEvent(perfil));
            }

            return await Task.FromResult(true);
        }
    }
}
