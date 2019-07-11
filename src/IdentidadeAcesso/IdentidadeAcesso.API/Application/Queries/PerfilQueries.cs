using IdentidadeAcesso.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PerfilQueries : IPerfilQueries
    {
        public async Task<PerfilViewModel> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PerfilViewModel>> ObterTodasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
