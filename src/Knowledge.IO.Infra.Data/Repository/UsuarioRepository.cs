using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using Knowledge.IO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IdentidadeAcessoContext context, IUnitOfWork uow) : base(context, uow)
        {

        }
    }
}
