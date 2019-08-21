using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using Knowledge.IO.Infra.Data.Context;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(IdentidadeAcessoDbContext context) : base(context)
        {

        }
    }
}
