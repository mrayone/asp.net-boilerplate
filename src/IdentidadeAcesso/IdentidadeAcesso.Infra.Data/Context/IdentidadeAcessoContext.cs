using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using Knowledge.IO.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.Context
{
    public class IdentidadeAcessoContext : DbContext
    {

        public const string DEFAULT_SCHEMA = "identidade";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public IdentidadeAcessoContext(DbContextOptions<IdentidadeAcessoContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfilEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoAssinadaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
        }
    }

    public class IdentidadeAcessoContextDesignFactory : IDesignTimeDbContextFactory<IdentidadeAcessoContext>
    {
        public IdentidadeAcessoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentidadeAcessoContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IdentidadeDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new IdentidadeAcessoContext(optionsBuilder.Options);
        }
    }
}
