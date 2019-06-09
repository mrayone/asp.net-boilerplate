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
            usuarioConfiguration.ToTable("usuarios", IdentidadeAcessoContext.DEFAULT_SCHEMA);
            usuarioConfiguration.HasKey(u => u.Id);
            usuarioConfiguration.Ignore(u => u.Erros);

            usuarioConfiguration.OwnsOne(u => u.Nome, n =>
            {
                n.Property(p => p.PrimeiroNome).HasColumnName("PrimeiroNome").IsRequired();
                n.Property(p => p.Sobrenome).HasColumnName("Sobrenome").IsRequired();
                n.Ignore(p => p.ValidationResult);
            });

            usuarioConfiguration.OwnsOne(u => u.Sexo, s =>
            {
                s.Property(p => p.Tipo).HasColumnName("Sexo").IsRequired();
                s.Ignore(p => p.ValidationResult);
            });

            usuarioConfiguration.OwnsOne(u => u.Status, st =>
            {
                st.Ignore(p => p.ValidationResult);
            });

            usuarioConfiguration.OwnsOne(u => u.Email, e => 
            {
                e.Property(p => p.Endereco).HasColumnName("Email").IsRequired();
                e.Ignore(p => p.ValidationResult);

            });

            usuarioConfiguration.OwnsOne(u => u.CPF, c => 
            {
                c.Property(p => p.Digitos).IsRequired();
                c.Ignore(p => p.ValidationResult);

            });

            usuarioConfiguration.OwnsOne(u => u.DataDeNascimento, d => 
            {
                d.Property(p => p.Data).IsRequired();
                d.Ignore(p => p.ValidationResult);

            });

            usuarioConfiguration.OwnsOne(u => u.Celular, c => 
            {
                c.Property(p => p.Numero).IsRequired(false);
                c.Ignore(p => p.ValidationResult);

            });

            usuarioConfiguration.OwnsOne(u => u.Telefone, t =>
            {
                t.Property(p => p.Numero).IsRequired(false);
                t.Ignore(p => p.ValidationResult);

            });

            usuarioConfiguration.OwnsOne(u => u.Endereco, e => 
            {
                e.ToTable("usuario_endereco");
                e.Ignore(p => p.ValidationResult);

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
