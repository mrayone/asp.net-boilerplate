﻿using IdentidadeAcesso.API.Application.Commands.CommandHandler;
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
    public class AtualizarPermissaoCommandHandler : BaseCommandHandler, IRequestHandler<AtualizarPermissaoCommand, bool>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;

        public AtualizarPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            IDomainNotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository) : base(mediator, unitOfWork, notifications)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AtualizarPermissaoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var permissao = await _permissaoRepository.ObterPorId(request.Id);
            if(permissao == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Permissão não encontrada."));
                return await Task.FromResult(false);
            }

            var permissaoBusca = await _permissaoRepository.Buscar(p => p.Atribuicao.Tipo == request.Tipo && p.Atribuicao.Valor == request.Valor && p.Id != request.Id);
            if (permissaoBusca.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Uma permissão com Tipo {request.Tipo} e Valor {request.Valor} já foi cadastrada. "));
                return await Task.FromResult(false);
            }

            permissao = this.DefinirPermissao(request);

            _permissaoRepository.Atualizar(permissao);

            if(await Commit())
            {
                await _mediator.Publish(new PermissaoAtualizadaEvent(permissao));
            }

            return await Task.FromResult(true);
        }
    }
}