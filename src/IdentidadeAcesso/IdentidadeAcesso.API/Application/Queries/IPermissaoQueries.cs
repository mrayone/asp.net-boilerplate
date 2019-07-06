using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public interface IPermissaoQueries
    {
        Task<PermissaoViewModel> ObterPorIdAsync(Guid id);
        Task<IEnumerable<PermissaoViewModel>> ObterTodas();
    }
}
