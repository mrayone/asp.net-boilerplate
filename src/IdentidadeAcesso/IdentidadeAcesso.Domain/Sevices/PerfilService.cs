using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
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
    public sealed class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _perfilRepo;
        private readonly IMediator _mediator;

        public PerfilService(IPerfilRepository perfilRepo, IMediator mediator)
        {
            _perfilRepo = perfilRepo;
            _mediator = mediator;
        }

        public async Task<Perfil> CancelarPermissoesAsync(List<PermissaoAssinada> permissoes, Guid perfilId)
        {
            var perfil = await _perfilRepo.ObterPorId(perfilId);

            foreach (var item in permissoes)
            {
                if(perfil.PermissoesAssinadas.Contains(item))
                {
                    perfil.CancelarPermissao(item.Id);
                }
            }

            return await Task.FromResult(perfil);
        }

        public async Task<bool> DeletarPerfil(Guid perfil)
        {
            return await Task.FromResult(false);
        }
    }
}
