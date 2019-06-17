using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class AtulizarPerfilCommandHandler : CommandHandler, IRequestHandler<AtualizarPerfilCommand, bool>
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

        public async Task<bool> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
        {
            var perfil = DefinirPerfil(request);

            if (!ValidarCommand(request, perfil))
            {
                return await Task.FromResult(false);
            };

            var perfilExistente = _perfilRepository.BuscarPorNome(request.Nome);
            if (perfilExistente != null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Um perfil com o nome {request.Nome} já existe."));
                return await Task.FromResult(false);
            }

            _perfilRepository.Adicionar(perfil);

            if (await Commit())
            {
                await _mediator.Publish(new PerfilAtualizadoEvent(perfil));
            }

            return await Task.FromResult(true);
        }

        private Perfil DefinirPerfil(AtualizarPerfilCommand request)
        {
            var perfil = new Perfil(new Identificacao(request.Nome, request.Descricao));

            foreach (var item in request.PermissoesAssinadas)
            {
                perfil.AssinarPermissao(item.PermissaoId);
            }

            return perfil;
        }
    }
}
