using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
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
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Erros);

            builder.Property<string>("PerfilId")
                .IsRequired();

            builder.HasOne<Permissao>()
                .WithMany()
                .HasForeignKey("PermissaoId");
        }
    }
}
