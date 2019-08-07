﻿// <auto-generated />
using System;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    [DbContext(typeof(IdentidadeAcessoDbContext))]
    [Migration("20190803004737_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.AtribuicaoPerfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("PerfilId");

                    b.Property<Guid>("PermissaoId");

                    b.Property<bool>("Status")
                        .HasColumnName("Ativo");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("atribuicoes_perfil","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("10ee538c-01a1-4e41-8956-2b5fae573708"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("7caecebf-9522-4e88-9d08-85ba2797caec"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("e4cc37cb-10e6-4d85-9c7b-862a472115a5"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("20f04a05-7732-428c-a5f2-1a5765256808"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("de256069-fea2-4ecf-919d-245ffcda5ed4"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("41e7bea1-7a95-4cdb-acc7-4b4c80620cf1"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("0440c348-12c2-435a-a027-f81636e71faa"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("414af151-1408-4ec6-b1a5-da2630989fa9"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("96a5e8ce-7432-4ccd-b733-6cfab29b4d32"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("563b8c28-58ff-4c0c-bb6d-9d98bc81ba5d"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("36479f98-6616-4893-a621-9c4da228637d"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("50b37aa3-cce4-41bf-b178-d1da4cfa5392"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("8ea60c9d-11c6-450d-a055-3ba269922a24"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("410eb828-8088-46fe-b046-09f3d0edac93"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("92950fb1-21ad-4dbd-89db-63d60300bbde"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"),
                            Status = true
                        },
                        new
                        {
                            Id = new Guid("2b9306d8-c823-4080-a051-a92ffdcc3edb"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            PermissaoId = new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"),
                            Status = true
                        });
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DeletadoEm");

                    b.HasKey("Id");

                    b.ToTable("perfis","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709")
                        });
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DeletadoEm");

                    b.HasKey("Id");

                    b.ToTable("permissoes","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453")
                        },
                        new
                        {
                            Id = new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576")
                        },
                        new
                        {
                            Id = new Guid("20f04a05-7732-428c-a5f2-1a5765256808")
                        },
                        new
                        {
                            Id = new Guid("f40ed114-8191-4621-8836-21aaf60eecf4")
                        },
                        new
                        {
                            Id = new Guid("0440c348-12c2-435a-a027-f81636e71faa")
                        },
                        new
                        {
                            Id = new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee")
                        },
                        new
                        {
                            Id = new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe")
                        },
                        new
                        {
                            Id = new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0")
                        },
                        new
                        {
                            Id = new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c")
                        },
                        new
                        {
                            Id = new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a")
                        },
                        new
                        {
                            Id = new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49")
                        },
                        new
                        {
                            Id = new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27")
                        },
                        new
                        {
                            Id = new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1")
                        },
                        new
                        {
                            Id = new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0")
                        });
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<Guid?>("PerfilId");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("usuarios","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                            PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                            Status = true
                        });
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.AtribuicaoPerfil", b =>
                {
                    b.HasOne("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Perfil")
                        .WithMany("Atribuicoes")
                        .HasForeignKey("PerfilId");

                    b.HasOne("IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Permissao")
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Perfil", b =>
                {
                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects.Identificacao", "Identifacao", b1 =>
                        {
                            b1.Property<Guid>("PerfilId");

                            b1.Property<string>("Descricao")
                                .IsRequired()
                                .HasColumnName("Descricao");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasColumnName("Nome");

                            b1.HasKey("PerfilId");

                            b1.ToTable("perfis","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Perfil")
                                .WithOne("Identifacao")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects.Identificacao", "PerfilId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    PerfilId = new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                                    Descricao = "Perfil de super usuário",
                                    Nome = "Administrador"
                                });
                        });
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Permissao", b =>
                {
                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects.Atribuicao", "Atribuicao", b1 =>
                        {
                            b1.Property<Guid>("PermissaoId");

                            b1.Property<string>("Tipo")
                                .IsRequired();

                            b1.Property<string>("Valor")
                                .IsRequired();

                            b1.HasKey("PermissaoId");

                            b1.ToTable("permissoes","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Permissao")
                                .WithOne("Atribuicao")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects.Atribuicao", "PermissaoId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    PermissaoId = new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"),
                                    Tipo = "Perfil",
                                    Valor = "Visualizar Perfis"
                                },
                                new
                                {
                                    PermissaoId = new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"),
                                    Tipo = "Perfil",
                                    Valor = "Revogar Permissões"
                                },
                                new
                                {
                                    PermissaoId = new Guid("20f04a05-7732-428c-a5f2-1a5765256808"),
                                    Tipo = "Perfil",
                                    Valor = "Atribuir Permissões"
                                },
                                new
                                {
                                    PermissaoId = new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"),
                                    Tipo = "Perfil",
                                    Valor = "Criar Perfil"
                                },
                                new
                                {
                                    PermissaoId = new Guid("0440c348-12c2-435a-a027-f81636e71faa"),
                                    Tipo = "Perfil",
                                    Valor = "Editar Perfil"
                                },
                                new
                                {
                                    PermissaoId = new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"),
                                    Tipo = "Perfil",
                                    Valor = "Excluir Perfil"
                                },
                                new
                                {
                                    PermissaoId = new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"),
                                    Tipo = "Permissão",
                                    Valor = "Criar Permissão"
                                },
                                new
                                {
                                    PermissaoId = new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"),
                                    Tipo = "Permissão",
                                    Valor = "Editar Permissão"
                                },
                                new
                                {
                                    PermissaoId = new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"),
                                    Tipo = "Permissão",
                                    Valor = "Visualizar Permissões"
                                },
                                new
                                {
                                    PermissaoId = new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"),
                                    Tipo = "Permissão",
                                    Valor = "Excluir Permissão"
                                },
                                new
                                {
                                    PermissaoId = new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"),
                                    Tipo = "Usuário",
                                    Valor = "Visualizar Usuários"
                                },
                                new
                                {
                                    PermissaoId = new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"),
                                    Tipo = "Usuário",
                                    Valor = "Criar Usuário"
                                },
                                new
                                {
                                    PermissaoId = new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"),
                                    Tipo = "Usuário",
                                    Valor = "Atualizar Usuário"
                                },
                                new
                                {
                                    PermissaoId = new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"),
                                    Tipo = "Usuário",
                                    Valor = "Excluir Usuário"
                                });
                        });
                });

            modelBuilder.Entity("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario", b =>
                {
                    b.HasOne("IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId");

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Digitos")
                                .HasColumnName("CPF");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("CPF")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.CPF", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                                    Digitos = "28999953084"
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.DataDeNascimento", "DataDeNascimento", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<DateTime>("Data");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("DataDeNascimento")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.DataDeNascimento", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                                    Data = new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("Email")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Email", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                                    Endereco = "adminfake@mozej.com"
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Bairro");

                            b1.Property<string>("Cep");

                            b1.Property<string>("Cidade");

                            b1.Property<string>("Complemento");

                            b1.Property<string>("Estado");

                            b1.Property<string>("Logradouro");

                            b1.Property<string>("Numero");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuario_endereco","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("Endereco")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Endereco", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa")
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.NomeCompleto", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasColumnName("Sobrenome");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("Nome")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.NomeCompleto", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                                    PrimeiroNome = "Maycon Rayone",
                                    Sobrenome = "Rodrigues Xavier"
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.NumerosContato", "NumerosContato", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("NumeroCel")
                                .HasColumnName("Celular");

                            b1.Property<string>("NumeroTelefone")
                                .HasColumnName("Telefone");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("NumerosContato")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.NumerosContato", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa")
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Senha", "Senha", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Caracteres")
                                .HasColumnName("Senha");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("Senha")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Senha", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                                    Caracteres = "AJCSz62DvWZLfooUaYj10vFYzwARYGBCpCx9CPQyoqNQtsphBev+ge2A5oK1lS1B2Q=="
                                });
                        });

                    b.OwnsOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Sexo", "Sexo", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Tipo")
                                .IsRequired()
                                .HasColumnName("Sexo");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios","dbo");

                            b1.HasOne("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Usuario")
                                .WithOne("Sexo")
                                .HasForeignKey("IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects.Sexo", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new
                                {
                                    UsuarioId = new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"),
                                    Tipo = "Masculino"
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}