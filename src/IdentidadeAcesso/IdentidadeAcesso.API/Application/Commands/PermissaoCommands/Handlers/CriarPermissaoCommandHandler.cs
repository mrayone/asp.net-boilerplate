using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PermissaoEvents;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class CriarPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<CriarPermissaoCommand, bool>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public CriarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository) : base(mediator, unitOfWork, notifications)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CriarPermissaoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var permissaoBusca = await _permissaoRepository.Buscar(p => p.Atribuicao.Tipo == request.Tipo && p.Atribuicao.Valor == request.Valor);
            if(permissaoBusca.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Uma permissão com Tipo {request.Tipo} e Valor {request.Valor} já foi cadastrada. "));
                return await Task.FromResult(false);
            }

            var permissao = this.DefinirPermissao(request);

            _permissaoRepository.Adicionar(permissao);

            if(await Commit())
            {
                await _mediator.Publish(new PermissaoCriadaEvent(permissao));
            }

            return await Task.FromResult(true);
        }
    }
}
