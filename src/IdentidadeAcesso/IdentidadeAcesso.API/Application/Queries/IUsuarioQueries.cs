using IdentidadeAcesso.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public interface IUsuarioQueries : IDisposable
    {
        Task<UsuarioViewModel> ObterPorIdAsync(Guid id);
        Task<IEnumerable<UsuarioViewModel>> ObterTodosAsync();
    }
}
