using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.Interfaces
{
    public interface IPerfilService
    {
        Task<bool> DeletarPerfilAsync(Perfil perfil);
        Task<Perfil> CancelarPermissaoAsync(Perfil perfil, Guid permissaoId);
        Task<Perfil> AssinarPermissaoAsync(Perfil perfil, Guid permissaoId);
    }
}
