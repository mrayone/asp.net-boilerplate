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
    public class PerfilEntityConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> perfilConfiguration)
        {
            perfilConfiguration.ToTable("perfis", IdentidadeAcessoDbContext.DEFAULT_SCHEMA);
            perfilConfiguration.HasKey(p => p.Id);

            perfilConfiguration.OwnsOne(p => p.Identifacao, i =>
            {
                i.Property(p => p.Descricao).HasColumnName("Descricao").IsRequired(false);
                i.Property(p => p.Nome).HasColumnName("Nome").IsRequired();
            });

            perfilConfiguration.Property(p => p.DeletadoEm)
                .IsRequired(false);

            var navigation = perfilConfiguration.Metadata.FindNavigation(nameof(Perfil.Atribuicoes));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
