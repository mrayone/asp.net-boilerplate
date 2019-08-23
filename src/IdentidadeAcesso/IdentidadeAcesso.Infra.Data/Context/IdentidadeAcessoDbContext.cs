using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Infra.Data.Context.Seed;
using IdentidadeAcesso.Infra.Data.EntityConfigurations;
using Knowledge.IO.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Knowledge.IO.Infra.Data.Context
{
    public class IdentidadeAcessoDbContext : DbContext
    {

        public const string DEFAULT_SCHEMA = "dbo";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TokenRedefinicaoSenha> TokensRedefinicaoSenha { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public IdentidadeAcessoDbContext(DbContextOptions<IdentidadeAcessoDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PerfilEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AtribuicoesPerfilEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissaoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TokenRedefinicaoSenhaEntityConfiguration());

            //TODO: Comente esta linha para executar testes do xUnit
            //modelBuilder.Seed(); 
        }
    }

    public class IdentidadeAcessoContextDesignFactory : IDesignTimeDbContextFactory<IdentidadeAcessoDbContext>
    {
        public IdentidadeAcessoDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<IdentidadeAcessoDbContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new IdentidadeAcessoDbContext(optionsBuilder.Options);
        }
    }
}
