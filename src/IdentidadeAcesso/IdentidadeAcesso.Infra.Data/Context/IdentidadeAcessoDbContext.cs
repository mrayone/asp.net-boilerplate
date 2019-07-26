using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Infra.Data.Context.Seed;
using Knowledge.IO.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.Context
{
    public class IdentidadeAcessoDbContext : DbContext
    {

        public const string DEFAULT_SCHEMA = "dbo";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public IdentidadeAcessoDbContext(DbContextOptions<IdentidadeAcessoDbContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PerfilEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoAssinadaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());

            //modelBuilder.Seed();
        }
    }

    public class IdentidadeAcessoContextDesignFactory : IDesignTimeDbContextFactory<IdentidadeAcessoDbContext>
    {
        public IdentidadeAcessoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentidadeAcessoDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IdentidadeDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new IdentidadeAcessoDbContext(optionsBuilder.Options);
        }
    }
}
