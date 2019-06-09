using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.EntityConfigurations
{
    public class PermissaoEntityConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("permissoes", IdentidadeAcessoContext.DEFAULT_SCHEMA);

            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Erros);

            builder.OwnsOne(p => p.Status, st =>
            {
                st.Ignore(p => p.ValidationResult);
            });

            builder.OwnsOne(p => p.Atribuicao, a =>
            {
                a.Property(p => p.Tipo).IsRequired();
                a.Property(p => p.Valor).IsRequired();
                a.Ignore(p => p.ValidationResult);
            });

        }
    }
}
