using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.interfaces
{
    public interface IPerfilService
    {
        Task<bool> DeletarPerfil(Guid perfilId);
        Task<Perfil> CancelarPermissoesAsync(List<PermissaoAssinada> permissoes, Guid perfilId);
    }
}
