using System;
using System.Linq;
using System.Threading.Tasks;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        private readonly IdentidadeAcessoDbContext _context;

        public PerfilRepository(IdentidadeAcessoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Perfil> ObterComPermissoesAsync(Guid id)
        {
            var perfil = await _context.Perfis.FindAsync(id); 
            if (perfil != null)
            {
                await _context.Entry(perfil)
                    .Collection(p => p.Atribuicoes).LoadAsync();
            }

            return perfil;
        }

        public async Task<Perfil> ObterComPermissoesAtivasAsync(Guid id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil != null)
            {
                await _context.Entry(perfil)
                    .Collection(p => p.Atribuicoes)
                    .Query().Where(a => a.Status == true)
                    .LoadAsync();
            }

            return perfil;
        }
    }
}
