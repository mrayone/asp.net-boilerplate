using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
    }
}
