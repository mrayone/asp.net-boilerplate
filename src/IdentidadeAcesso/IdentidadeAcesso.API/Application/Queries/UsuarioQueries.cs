using IdentidadeAcesso.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class UsuarioQueries : IUsuarioQueries
    {
        public async Task<UsuarioViewModel> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObterTodasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
