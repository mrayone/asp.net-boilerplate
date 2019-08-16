using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterUsuarioPorEmailAsync(string email);
    }
}
