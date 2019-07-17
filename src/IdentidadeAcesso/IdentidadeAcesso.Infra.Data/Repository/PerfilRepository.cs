using System;
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

        public void Atualizar(Perfil perfil)
        {
            _context.Entry(perfil).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            base.Atualizar(perfil);
        }

        public async Task<Perfil> ObterComPermissoesAsync(Guid id)
        {
            var perfil = await base.ObterPorIdAsync(id);
            if (perfil != null)
            {
                await _context.Entry(perfil)
                    .Collection(p => p.PermissoesAssinadas).LoadAsync();
            }

            return perfil;
        }
    }
}
