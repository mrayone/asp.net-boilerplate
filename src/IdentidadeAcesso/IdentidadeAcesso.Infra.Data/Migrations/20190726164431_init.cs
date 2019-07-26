using System;
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
                    CPF = table.Column<string>(nullable: false),
                    DataDeNascimento_Data = table.Column<DateTime>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
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
                name: "permissoes_assinadas",
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
                    table.PrimaryKey("PK_permissoes_assinadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissoes_assinadas_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "dbo",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_permissoes_assinadas_permissoes_PermissaoId",
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
                values: new object[] { new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), null, "Perfil administrativo", "Administrativo" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes",
                columns: new[] { "Id", "DeletadoEm", "Atribuicao_Tipo", "Atribuicao_Valor" },
                values: new object[] { new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), null, "Perfil", "Visualizar Perfis" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes_assinadas",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[] { new Guid("713ef553-e426-40e3-a81f-3ba0f10ee4d8"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("fd2800a1-a5be-4935-94e9-60af47ebdc13"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "maycon.rayone@gmail.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "ANBvyxKEBm85krUwGWyCdeRaE0IYJxEzUoec8QKBfg+Gy1Eu60Ht+cxxPrn6jf7SWA==", "Masculino" });

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_assinadas_PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_assinadas_PermissaoId",
                schema: "dbo",
                table: "permissoes_assinadas",
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
                name: "permissoes_assinadas",
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
