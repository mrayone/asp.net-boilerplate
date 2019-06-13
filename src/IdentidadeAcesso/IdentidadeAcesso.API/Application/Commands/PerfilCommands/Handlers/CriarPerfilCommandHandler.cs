using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using System;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using System.Linq;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class CriarPerfilCommandHandler : CommandHandler ,IRequestHandler<CriarPerfilCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarPerfilCommandHandler(IMediator mediator, 
            IPerfilRepository perfilRepository, 
            IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilRepository = perfilRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CriarPerfilCommand request, CancellationToken cancellationToken)
        {
            if (!request.isValid())
            {
                NotificarErros(request);
                return await Task.FromResult(false);
            };

            var perfilExistente = _perfilRepository.BuscarPorNome(request.Nome);
            if (perfilExistente != null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Um perfil com o nome {request.Nome} já existe."));
                return await Task.FromResult(false);
            }

            var perfil = DefinirPerfil(request);

            _perfilRepository.Adicionar(perfil);
            
            if(await Commit())
            {
                await _mediator.Publish(new PerfilCriadoEvent(perfil));
            }

            return await Task.FromResult(true);
        }

        private Perfil DefinirPerfil(CriarPerfilCommand request)
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
