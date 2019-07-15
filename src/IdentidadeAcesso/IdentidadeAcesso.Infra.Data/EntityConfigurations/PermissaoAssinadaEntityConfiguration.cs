using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.EntityConfigurations
{
    class PermissaoAssinadaEntityConfiguration : IEntityTypeConfiguration<PermissaoAssinada>
    {
        public void Configure(EntityTypeBuilder<PermissaoAssinada> builder)
        {
            builder.ToTable("permissoes_assinadas", IdentidadeAcessoDbContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Status);

            builder.HasOne<Permissao>()
                .WithMany()
                .HasForeignKey("PermissaoId");
        }
    }
}
