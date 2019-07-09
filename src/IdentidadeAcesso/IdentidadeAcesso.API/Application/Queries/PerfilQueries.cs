using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PerfilQueries : IPerfilQueries
    {
        public Task<PerfilViewModel> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PerfilViewModel>> ObterTodasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
