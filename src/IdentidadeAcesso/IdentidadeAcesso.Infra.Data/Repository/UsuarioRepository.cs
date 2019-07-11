using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using Knowledge.IO.Infra.Data.Context;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IdentidadeAcessoContext context) : base(context)
        {

        }
    }
}
