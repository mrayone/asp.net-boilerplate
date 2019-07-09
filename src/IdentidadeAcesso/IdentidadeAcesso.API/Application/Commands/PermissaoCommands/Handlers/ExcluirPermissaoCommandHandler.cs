using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class ExcluirPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<ExcluirPermissaoCommand, bool>
    {
        private readonly IPermissaoService _permissaoService;
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public ExcluirPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository,
            IPermissaoService service) : base(mediator, unitOfWork, notifications)
        {
            _permissaoService = service;
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(ExcluirPermissaoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);
            var permissao = await _permissaoRepository.ObterPorId(request.PermissaoId);

            if(permissao == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Permissão não encontrada."));
                return await Task.FromResult(false);
            }

            var result = await _permissaoService.DeletarPermissaoAsync(permissao);
            if(!result) return await Task.FromResult(false);

            if(await Commit())
            {
                await _mediator.Publish(new PermissaoExcluidaEvent(permissao));
            }

            return await Task.FromResult(true);
        }
    }
}
