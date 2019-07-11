using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        protected IdentidadeAcessoContext Context;
        protected DbSet<TEntity> DbSet;

        public Repository(IdentidadeAcessoContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            var result = DbSet.AsNoTracking().Where(predicate);

            return await Task.FromResult(result);  
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
