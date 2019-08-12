using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
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
    public class AtribuirPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<AtribuirPermissaoCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilService _perfilService;
        private readonly IPerfilRepository _perfilRepository;

        public AtribuirPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications, IPerfilService domainService,
            IPerfilRepository perfilRespository) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilService = domainService;
            _perfilRepository = perfilRespository;
        }

        public async Task<CommandResponse> Handle(AtribuirPermissaoCommand request, CancellationToken cancellationToken)
        {
            var perfil = await this.BuscarPerfilComPermissoes(request.PerfilId, _perfilRepository);
            if (perfil == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Perfil não encontrado."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            foreach (var item in request.Atribuicoes)
            {
                if (item.Ativa) perfil = await _perfilService.AtribuirPermissaoAsync(perfil, item.PermissaoId);
                else perfil = await _perfilService.RevogarPermissaoAsync(perfil, item.PermissaoId);
            }

            if (await Commit())
            {
                await _mediator.Publish(new PermissaoAssinadaEvent(perfil));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
