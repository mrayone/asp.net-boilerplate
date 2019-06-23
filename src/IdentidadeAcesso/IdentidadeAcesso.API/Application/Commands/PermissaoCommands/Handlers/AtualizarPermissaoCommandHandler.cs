using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class AtualizarPermissaoCommandHandler : CommandHandler, IRequestHandler<AtualizarPermissaoCommand, bool>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public AtualizarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository) : base(mediator, unitOfWork, notifications)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AtualizarPermissaoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var permissaoBusca = await _permissaoRepository.Buscar(p => p.Atribuicao.Tipo == request.Tipo && p.Atribuicao.Valor == request.Valor && p.Id != request.Id);
            if (permissaoBusca.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Uma permissão com Tipo {request.Tipo} e Valor {request.Valor} já foi cadastrada. "));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
