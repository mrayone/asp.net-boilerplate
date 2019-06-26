using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<CommandResponse> Commit();
    }
}
