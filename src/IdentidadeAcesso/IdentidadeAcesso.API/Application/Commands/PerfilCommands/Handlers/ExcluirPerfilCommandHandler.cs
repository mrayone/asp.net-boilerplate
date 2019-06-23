using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class ExcluirPerfilCommandHandler : CommandHandler, IRequestHandler<ExcluirPerfilCommand, bool>
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

        public async Task<bool> Handle(ExcluirPerfilCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            if(!await PerfilExitente(request)) return await Task.FromResult(false);

            var perfil = await _perfilRepository.ObterPorId(request.Id);
            if(!await _domainService.DeletarPerfil(perfil.Id))
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Este perfil está em uso e não pode ser deletado."));
                return await Task.FromResult(false);
            }

            if(await Commit())
            {
                await _mediator.Publish(new PerfilDeletadoEvent(perfil));
            }

            return await Task.FromResult(true);
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
