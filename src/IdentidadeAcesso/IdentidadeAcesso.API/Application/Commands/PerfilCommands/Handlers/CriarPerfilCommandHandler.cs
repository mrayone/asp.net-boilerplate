using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class CriarPerfilCommandHandler : BaseCommandHandler, IRequestHandler<CriarPerfilCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;

        public CriarPerfilCommandHandler(IMediator mediator, 
            IPerfilRepository perfilRepository, 
            IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilRepository = perfilRepository;
        }

        public async Task<CommandResponse> Handle(CriarPerfilCommand request, CancellationToken cancellationToken)
        {
            var perfil = this.DefinirPerfil(request);

            var perfilExistente = await _perfilRepository.Buscar(p => p.Identifacao.Nome == request.Nome);
            if (perfilExistente.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Um perfil com o nome {request.Nome} já existe."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            _perfilRepository.Adicionar(perfil);
            
            if(await Commit())
            {
                await _mediator.Publish(new PerfilCriadoEvent(perfil));
            }

            return await Task.FromResult(CommandResponse.Ok);

        }
    }
}
