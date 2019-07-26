using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Infra.Data.Context.Seed
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissao>(p =>
            {
                p.HasData(new
                {
                    Id = new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453")
                });
                p.OwnsOne(prop => prop.Atribuicao)
                .HasData(
                    new
                    {
                        PermissaoId = new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"),
                        Tipo = "Perfil",
                        Valor = "Visualizar Perfis"
                    });
            });
            modelBuilder.Entity<Perfil>(p =>
            {
                p.HasData(new
                {
                    Id = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709")
                });

                p.OwnsOne(prop => prop.Identifacao)
                .HasData(
                        new
                        {
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            Nome = "Administrativo",
                            Descricao = "Perfil administrativo"
                        });
            });
            modelBuilder.Entity<PermissaoAssinada>(p => 
            {
                p.HasData(new
                {
                    Id = Guid.NewGuid(),
                    PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                    PermissaoId = new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"),
                    Status =  true,
                });
            });
            modelBuilder.Entity<Usuario>(u => 
            {
                var uId = Guid.NewGuid();
                u.HasData(new
                {
                    Id = uId,
                    PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                    Status =  true
                });

                u.OwnsOne(p => p.CPF).HasData(new
                {
                    UsuarioId = uId,
                    Digitos = "28999953084"
                });

                u.OwnsOne(p => p.Sexo).HasData(new
                {
                    UsuarioId = uId,
                    Tipo = "Masculino"
                });

                u.OwnsOne(p => p.DataDeNascimento).HasData(new
                {
                    UsuarioId = uId,
                    Data = new DateTime(1993, 7, 22)
                });

                u.OwnsOne(p => p.Email).HasData(new
                {
                    UsuarioId = uId,
                    Endereco = "maycon.rayone@gmail.com"
                });

                u.OwnsOne(p => p.Nome).HasData(new
                {
                    UsuarioId = uId,
                    PrimeiroNome = "Maycon Rayone",
                    Sobrenome = "Rodrigues Xavier"
                });

                u.OwnsOne(p => p.Senha).HasData(new
                {
                    UsuarioId = uId,
                    Caracteres = Senha.GerarSenha("28999953084").Caracteres.ToString()
                });

                u.OwnsOne(p => p.NumerosContato).HasData(new { UsuarioId = uId });
            });
        }
    }
}
