using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}
