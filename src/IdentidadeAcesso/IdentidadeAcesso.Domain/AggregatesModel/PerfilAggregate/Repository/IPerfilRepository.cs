using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        Task<Perfil> ObterComPermissoesAsync(Guid id);
        Task<Perfil> ObterComPermissoesAtivasAsync (Guid id);
    }
}
