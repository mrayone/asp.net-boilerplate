using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using Knowledge.IO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IdentidadeAcessoContext Context;

        public UnitOfWork(IdentidadeAcessoContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CommandResponse Commit()
        {
            return Context.SaveChanges() > 0 ? CommandResponse.Ok : CommandResponse.Fail;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
