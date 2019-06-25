using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.Sevices
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly IMediator _mediator;
        private readonly IPerfilRepository _perfilRepository;
        public PermissaoService(IPermissaoRepository permissaoRepository, IMediator mediator, IPerfilRepository perfilRepository)
        {
            _permissaoRepository = permissaoRepository;
            _mediator = mediator;
            _perfilRepository = perfilRepository;
        }

        public async Task<bool> DeletarPermissao(Permissao permissao)
        {
            var perfilComPermissao = await _perfilRepository.Buscar(p => p.PermissoesAssinadas.Select(per => per.PermissaoId == permissao.Id).Any());

            if (!perfilComPermissao.Any())
            {
                permissao.Deletar();
                return await Task.FromResult(true);
            }

            await _mediator.Publish(new DomainNotification(GetType().Name, "Não foi possível deletar esta permissão, pois a mesma está em uso."));
            return await Task.FromResult(false);
        }
    }
}
