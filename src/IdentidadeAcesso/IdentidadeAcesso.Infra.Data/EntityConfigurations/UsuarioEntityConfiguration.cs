using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.EntityConfigurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> usuarioConfiguration)
        {
            usuarioConfiguration.ToTable("usuarios", IdentidadeAcessoDbContext.DEFAULT_SCHEMA);
            usuarioConfiguration.HasKey(u => u.Id);

            usuarioConfiguration.OwnsOne(u => u.Nome, n =>
            {
                n.Property(p => p.PrimeiroNome).HasColumnName("PrimeiroNome").IsRequired();
                n.Property(p => p.Sobrenome).HasColumnName("Sobrenome").IsRequired();
            });

            usuarioConfiguration.OwnsOne(u => u.Sexo, s =>
            {
                s.Property(p => p.Tipo).HasColumnName("Sexo").IsRequired();
            });

            usuarioConfiguration.OwnsOne(u => u.Status);

            usuarioConfiguration.OwnsOne(u => u.Email, e => 
            {
                e.Property(p => p.Endereco).HasColumnName("Email").IsRequired();
            });

            usuarioConfiguration.OwnsOne(u => u.CPF, c => 
            {
                c.Property(p => p.Digitos).IsRequired();
            });

            usuarioConfiguration.OwnsOne(u => u.DataDeNascimento, d => 
            {
                d.Property(p => p.Data).IsRequired();
            });

            usuarioConfiguration.OwnsOne(u => u.Celular, c => 
            {
                c.Property(p => p.Numero).IsRequired(false);
            });

            usuarioConfiguration.OwnsOne(u => u.Telefone, t =>
            {
                t.Property(p => p.Numero).IsRequired(false);
            });

            usuarioConfiguration.OwnsOne(u => u.Endereco, e => 
            {
                e.ToTable("usuario_endereco");
            });

            usuarioConfiguration.Property(u => u.DeletadoEm)
                .IsRequired(false);

            usuarioConfiguration.HasOne<Perfil>()
                .WithMany()
                .HasForeignKey("PerfilId")
                .IsRequired();
        }
    }
}
