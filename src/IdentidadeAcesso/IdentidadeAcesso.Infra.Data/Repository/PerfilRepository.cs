using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using Knowledge.IO.Infra.Data.Context;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(IdentidadeAcessoDbContext context) : base(context)
        {

        }
    }
}
