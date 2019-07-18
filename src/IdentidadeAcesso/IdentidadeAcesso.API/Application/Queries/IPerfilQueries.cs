using IdentidadeAcesso.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public interface IPerfilQueries : IDisposable
    {
        Task<PerfilViewModel> ObterPorIdAsync(Guid id);
        Task<IEnumerable<PerfilViewModel>> ObterTodasAsync();
    }
}
