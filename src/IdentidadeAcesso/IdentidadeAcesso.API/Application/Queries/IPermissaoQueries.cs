using IdentidadeAcesso.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public interface IPermissaoQueries : IDisposable
    {
        Task<PermissaoViewModel> ObterPorIdAsync(Guid id);
        Task<IEnumerable<PermissaoViewModel>> ObterTodasAsync();
    }
}
