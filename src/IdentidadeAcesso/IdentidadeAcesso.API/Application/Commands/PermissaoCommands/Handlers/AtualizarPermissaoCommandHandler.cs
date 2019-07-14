using IdentidadeAcesso.API.Application.Behaviors;
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
    public class AtualizarPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<AtualizarPermissaoCommand, Response>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public AtualizarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository) : base(mediator, unitOfWork, notifications)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<Response> Handle(AtualizarPermissaoCommand request, CancellationToken cancellationToken)
        {
            var permissao = await _permissaoRepository.ObterPorId(request.Id);
            if(permissao == null)
            {
                return await Task.FromResult(new Response().AddError($"Permissão não encontrada."));
            }

            var permissaoBusca = await _permissaoRepository.Buscar(p => p.Atribuicao.Tipo == request.Tipo && p.Atribuicao.Valor == request.Valor && p.Id != request.Id);
            if (permissaoBusca.Any())
            {
                return await Task.FromResult(new Response().AddError($"Uma permissão com Tipo {request.Tipo} e Valor {request.Valor} já foi cadastrada. "));
            }

            permissao = this.DefinirPermissao(request);

            _permissaoRepository.Atualizar(permissao);

            if(await Commit())
            {
                await _mediator.Publish(new PermissaoAtualizadaEvent(permissao));
            }

            return await Task.FromResult(new Response());
        }
    }
}
