using System;
using System.Threading.Tasks;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using Knowledge.IO.Infra.Data.Context;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        private readonly IdentidadeAcessoDbContext _context;

        public PerfilRepository(IdentidadeAcessoDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Perfil> ObterPorId(Guid id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if(perfil != null)
            {
                await _context.Entry(perfil)
                    .Collection(p => p.PermissoesAssinadas).LoadAsync();
            }

            return perfil;
        }

        public void Atualizar(Perfil perfil)
        {
            _context.Entry(perfil).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            base.Atualizar(perfil);
        }
    }
}
