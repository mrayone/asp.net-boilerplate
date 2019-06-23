using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.Sevices
{
    public class PerfilService : IPerfilService
    {
        public Task<Perfil> CancelarPermissoes(List<PermissaoAssinada> permissoes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarPerfil(Guid perfil)
        {
            throw new NotImplementedException();
        }
    }
}
