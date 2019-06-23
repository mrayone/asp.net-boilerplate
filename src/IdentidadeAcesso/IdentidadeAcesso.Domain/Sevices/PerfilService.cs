using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.Sevices
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _perfilRepo;
        private readonly IMediator _mediator;

        public PerfilService(IPerfilRepository perfilRepo, IMediator mediator)
        {
            _perfilRepo = perfilRepo;
            _mediator = mediator;
        }


        public Task<Perfil> CancelarPermissoes(List<PermissaoAssinada> permissoes, Guid perfilId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarPerfil(Guid perfil)
        {
            throw new NotImplementedException();
        }
    }
}
