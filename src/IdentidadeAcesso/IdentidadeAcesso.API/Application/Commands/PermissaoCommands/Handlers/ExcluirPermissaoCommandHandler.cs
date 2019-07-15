using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class ExcluirPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<ExcluirPermissaoCommand, CommandResponse>
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

        public async Task<CommandResponse> Handle(ExcluirPermissaoCommand request, CancellationToken cancellationToken)
        {
            var permissao = await _permissaoRepository.ObterPorId(request.PermissaoId);

            if(permissao == null)
            {
                return await Task.FromResult(new CommandResponse().AddError("Permissão não encontrada."));
            }

            var result = await _permissaoService.DeletarPermissaoAsync(permissao);
            if(!result) return await Task.FromResult(new CommandResponse().AddError("Não foi possível deletar a permissão."));


            if (await Commit())
            {
                await _mediator.Publish(new PermissaoExcluidaEvent(permissao));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
