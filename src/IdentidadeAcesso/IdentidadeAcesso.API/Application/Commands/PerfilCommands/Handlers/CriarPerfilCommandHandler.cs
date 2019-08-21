using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.Events.PerfilEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers
{
    public class CriarPerfilCommandHandler : BaseCommandHandler, IRequestHandler<CriarPerfilCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IPerfilService _perfilService;

        public CriarPerfilCommandHandler(IMediator mediator, 
            IPerfilRepository perfilRepository, IPerfilService domainService,
            IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilRepository = perfilRepository;
            _perfilService = domainService;
        }

        public async Task<CommandResponse> Handle(CriarPerfilCommand request, CancellationToken cancellationToken)
        {
            var perfil = this.DefinirPerfil(request);

            var perfilExistente = await _perfilRepository.Buscar(p => p.Identifacao.Nome == request.Nome && p.DeletadoEm == null);
            if (perfilExistente.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, $"Um perfil com o nome {request.Nome} já existe."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            foreach (var item in request.Atribuicoes)
            {
                if (item.Ativo) perfil = await _perfilService.AtribuirPermissaoAsync(perfil, item.PermissaoId);
                else perfil = await _perfilService.RevogarPermissaoAsync(perfil, item.PermissaoId);
            }

            _perfilRepository.Adicionar(perfil);
            
            if(await Commit())
            {
                await _mediator.Publish(new PerfilCriadoEvent(perfil));
            }

            return await Task.FromResult(CommandResponse.Ok);

        }
    }
}
