using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class ExcluirPerfilCommandHandler : BaseCommandHandler, IRequestHandler<ExcluirPerfilCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly INotificationHandler<DomainNotification> _notifications;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IPerfilService _domainService;
        public ExcluirPerfilCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications, 
            IPerfilRepository perfilRepository, IPerfilService domainService) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _notifications = notifications;
            _perfilRepository = perfilRepository;
            _domainService = domainService;
        }

        public async Task<CommandResponse> Handle(ExcluirPerfilCommand request, CancellationToken cancellationToken)
        {

            if(!await PerfilExitente(request)) return await Task.FromResult(CommandResponse.Fail);

            var perfil = await _perfilRepository.ObterPorId(request.Id);
            if(!await _domainService.DeletarPerfilAsync(perfil))
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Este perfil está em uso e não pode ser deletado."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            if(await Commit())
            {
                await _mediator.Publish(new PerfilDeletadoEvent(perfil));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }

        private async Task<bool> PerfilExitente(ExcluirPerfilCommand request)
        {
            var perfil = await _perfilRepository.ObterPorId(request.Id);
            if (perfil != null) return await Task.FromResult(true);

            await _mediator.Publish(new DomainNotification(request.GetType().Name, "Perfil não encontrado."));
            return await Task.FromResult(false);
        }
    }
}
