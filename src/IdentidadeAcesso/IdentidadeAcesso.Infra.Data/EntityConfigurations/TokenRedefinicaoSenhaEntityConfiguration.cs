using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Infra.Data.EntityConfigurations
{
    public class TokenRedefinicaoSenhaEntityConfiguration : IEntityTypeConfiguration<TokenRedefinicaoSenha>
    {
        public void Configure(EntityTypeBuilder<TokenRedefinicaoSenha> builder)
        {
            builder.ToTable("tokens_de_redefinicao", IdentidadeAcessoDbContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Token);
            builder.Property(p => p.CriadoEm).IsRequired(false);

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("UsuarioId");
        }
    }
}
