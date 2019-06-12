using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using Knowledge.IO.Infra.Data.Context;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(IdentidadeAcessoContext context) : base(context)
        {

        }
    }
}
