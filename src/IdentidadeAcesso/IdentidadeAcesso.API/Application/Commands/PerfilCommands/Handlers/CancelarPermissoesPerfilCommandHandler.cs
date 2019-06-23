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
    public class CancelarPermissoesPerfilCommandHandler : CommandHandler, IRequestHandler<CancelarPermissoesPerfilCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPerfilService _perfilService;
        private readonly IPerfilRepository _perfilRepository;

        public CancelarPermissoesPerfilCommandHandler(IMediator mediator, IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications, IPerfilService domainService, 
            IPerfilRepository perfilRespository) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _perfilService = domainService;
            _perfilRepository = perfilRespository;
        }

        public async Task<bool> Handle(CancelarPermissoesPerfilCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            if (!await PerfilExiste(request)) return await Task.FromResult(false);

            var permissoesAssinadas = DefinirPermissoes(request.PermissoesAssinadas);
            var perfil = await _perfilService.CancelarPermissoes(permissoesAssinadas, request.PerfilId);
            if (perfil == null )
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, 
                    "Ocorreu um problema ao cancelar as permissões, verifique se estas já estavam assinadas."));

                return await Task.FromResult(false);
            }

            if (await Commit())
            {
                await _mediator.Publish(new PermissaoCanceladaEvent(perfil));
            }

            return await Task.FromResult(true);
        }

        private List<PermissaoAssinada> DefinirPermissoes(IList<PermissaoAssinadaDTO> permissoesAssinadas)
        {
            var list = new List<PermissaoAssinada>();

            foreach(var item in permissoesAssinadas)
            {
                if (!item.Status)
                {
                    list.Add(new PermissaoAssinada(item.PermissaoId));
                }
            }

            return list;
        }

        private async Task<bool> PerfilExiste(CancelarPermissoesPerfilCommand request)
        {
            var perfil = _perfilRepository.ObterPorId(request.PerfilId);
            if (perfil != null)  return await Task.FromResult(true);

            await _mediator.Publish(new DomainNotification(request.GetType().Name, "Perfil não encontrado."));

            return await Task.FromResult(false);
        }
    }
}
