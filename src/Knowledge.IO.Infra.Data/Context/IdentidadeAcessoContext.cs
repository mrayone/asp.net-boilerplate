using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;

namespace Knowledge.IO.Infra.Data.Context
{
    public class IdentidadeAcessoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }


        public IdentidadeAcessoContext(DbContextOptions<IdentidadeAcessoContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

    public class IdentidadeAcessoContextDesignFactory : IDesignTimeDbContextFactory<IdentidadeAcessoContext>
    {
        public IdentidadeAcessoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentidadeAcessoContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KnowledgeIO;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new IdentidadeAcessoContext(optionsBuilder.Options);
        }
    }
}
