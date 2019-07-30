﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "perfis",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissoes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Atribuicao_Valor = table.Column<string>(nullable: false),
                    Atribuicao_Tipo = table.Column<string>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    DataDeNascimento_Data = table.Column<DateTime>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    PerfilId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "dbo",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "atribuicoes_perfil",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    PermissaoId = table.Column<Guid>(nullable: false),
                    PerfilId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atribuicoes_perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_atribuicoes_perfil_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "dbo",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_atribuicoes_perfil_permissoes_PermissaoId",
                        column: x => x.PermissaoId,
                        principalSchema: "dbo",
                        principalTable: "permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_endereco",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_endereco", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_usuario_endereco_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "perfis",
                columns: new[] { "Id", "DeletadoEm", "Descricao", "Nome" },
                values: new object[,]
                {
                    { new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), null, "Perfil de super usuário", "Administrador" },
                    { new Guid("21dae14c-632b-4768-bfab-722bd291c785"), null, "Perfil para usuários visitantes no sistema.", "Visitante" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes",
                columns: new[] { "Id", "DeletadoEm", "Atribuicao_Tipo", "Atribuicao_Valor" },
                values: new object[,]
                {
                    { new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), null, "Perfil", "Visualizar Perfis" },
                    { new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), null, "Perfil", "Revogar Permissões" },
                    { new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), null, "Perfil", "Atribuir Permissões" },
                    { new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), null, "Perfil", "Criar Perfil" },
                    { new Guid("0440c348-12c2-435a-a027-f81636e71faa"), null, "Perfil", "Editar Perfil" },
                    { new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), null, "Perfil", "Excluir Perfil" },
                    { new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), null, "Permissão", "Criar Permissão" },
                    { new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), null, "Permissão", "Editar Permissão" },
                    { new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), null, "Permissão", "Visualizar Permissões" },
                    { new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), null, "Permissão", "Excluir Permissão" },
                    { new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), null, "Usuário", "Visualizar Usuários" },
                    { new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), null, "Usuário", "Criar Usuário" },
                    { new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), null, "Usuário", "Atualizar Usuário" },
                    { new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), null, "Usuário", "Excluir Usuário" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("f28d0c97-c858-44b9-94dd-70aa924a493a"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("47436253-e502-44e4-b840-630874332520"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("fbafbdab-3dfa-4993-a5d8-72550600bd29"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("6a9f5e86-a294-4cc7-a32b-8512c0e0032f"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("0a4a6f9a-6074-485b-83e7-c59add9bcde6"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("5bad22b2-5ea7-430a-a40d-37c093c14b4a"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("9398bed2-7f37-40ae-8adc-932b9967a02a"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("735bff70-6cd7-4b47-817c-256c1d85488e"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("a2fbe481-4203-4857-a25f-1cf84f1fb8ac"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("faccdb14-5d50-4e29-850e-f0c6d39ac8f0"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("35ec79ad-90d5-4146-9014-999689cad662"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("3f161ec6-fd5c-4a96-ad91-50984d03e695"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("1266424b-80dd-40b6-aec2-a1b00efb2fd6"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("d8a8a224-01f4-405d-b528-4da6fa7b14ff"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("c83d1b3b-f00e-49eb-a820-34229d2bd69c"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "ABYDrL0yZrfv0QOGRR6llhOukuHsw+c1Y0uFXca1pBK7bB/AwUiRIzJm+rVbr0ErIQ==", "Masculino" });

            migrationBuilder.CreateIndex(
                name: "IX_atribuicoes_perfil_PerfilId",
                schema: "dbo",
                table: "atribuicoes_perfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_atribuicoes_perfil_PermissaoId",
                schema: "dbo",
                table: "atribuicoes_perfil",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_PerfilId",
                schema: "dbo",
                table: "usuarios",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atribuicoes_perfil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "usuario_endereco",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "permissoes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "perfis",
                schema: "dbo");
        }
    }
}