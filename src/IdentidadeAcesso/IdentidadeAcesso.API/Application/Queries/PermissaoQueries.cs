using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PermissaoQueries : IPermissaoQueries
    {
        public Task<PermissaoViewModel> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PermissaoViewModel>> ObterTodasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
