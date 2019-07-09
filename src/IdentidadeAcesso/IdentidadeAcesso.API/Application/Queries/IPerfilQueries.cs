using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public interface IPerfilQueries
    {
        Task<PerfilViewModel> ObterPorIdAsync(Guid id);
        Task<IEnumerable<PerfilViewModel>> ObterTodasAsync();
    }
}
