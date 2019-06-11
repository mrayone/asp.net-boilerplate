using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using Knowledge.IO.Infra.Data.Context;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PerfilPermissaoRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilPermissaoRepository(IdentidadeAcessoContext context) : base(context)
        {

        }
    }
}
