using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class CancelarPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<CancelarPermissaoCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilService _perfilService;
        private readonly IPerfilRepository _perfilRepository;

        public CancelarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications, IPerfilService domainService, 
            IPerfilRepository perfilRespository) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilService = domainService;
            _perfilRepository = perfilRespository;
        }

        public async Task<CommandResponse> Handle(CancelarPermissaoCommand request, CancellationToken cancellationToken)
        {
            var perfil = await this.BuscarPerfil(request.PerfilId, _perfilRepository);
            if (perfil == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Perfil não encontrado."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            foreach (var item in request.Assinaturas)
            {
                perfil = await _perfilService.CancelarPermissaoAsync(perfil, item.PermissaoId);
            }

            if (await Commit())
            {
                await _mediator.Publish(new AssinaturaPermissaoCanceladaEvent(perfil));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
