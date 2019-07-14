using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class CriarPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<CriarPermissaoCommand, CommandResponse>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public CriarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository) : base(mediator, unitOfWork, notifications)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(CriarPermissaoCommand request, CancellationToken cancellationToken)
        {
            var permissaoBusca = await _permissaoRepository.Buscar(p => p.Atribuicao.Tipo == request.Tipo && p.Atribuicao.Valor == request.Valor);
            if(permissaoBusca.Any())
            {
                return await Task.FromResult(new CommandResponse().AddError($"Uma permissão com Tipo {request.Tipo} e Valor {request.Valor} já foi cadastrada. "));
            }

            var permissao = this.DefinirPermissao(request);

            _permissaoRepository.Adicionar(permissao);

            if(await Commit())
            {
                await _mediator.Publish(new PermissaoCriadaEvent(permissao));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
