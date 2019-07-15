﻿using IdentidadeAcesso.API.Application.Commands.CommandHandler;
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
    public class AtulizarPerfilCommandHandler : BaseCommandHandler, IRequestHandler<AtualizarPerfilCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtulizarPerfilCommandHandler(IMediator mediator, 
            IPerfilRepository perfilRepository, 
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications )
        {
            _mediator = mediator;
            _perfilRepository = perfilRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
        {
            if ( !await PerfilExitente(request)) return await Task.FromResult(CommandResponse.Fail);

            var perfil = this.DefinirPerfil(request);

            var perfilExistente = await _perfilRepository.Buscar(p => p.Identifacao.Nome == request.Nome);
            if (perfilExistente.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Um perfil com o nome {request.Nome} já existe."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            _perfilRepository.Atualizar(perfil);

            if (await Commit())
            {
                await _mediator.Publish(new PerfilAtualizadoEvent(perfil));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }

        private async Task<bool> PerfilExitente(AtualizarPerfilCommand request)
        {
            var perfil = await _perfilRepository.ObterPorId(request.Id);
            if (perfil != null) return await Task.FromResult(true);

            await _mediator.Publish(new DomainNotification(request.GetType().Name, "Perfil não encontrado."));
            return await Task.FromResult(true);
        }

    }
}
