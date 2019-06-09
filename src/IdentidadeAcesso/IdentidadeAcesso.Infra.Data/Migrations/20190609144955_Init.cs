using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identidade");

            migrationBuilder.CreateTable(
                name: "perfis",
                schema: "identidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    Status_Valor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissoes",
                schema: "identidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Atribuicao_Valor = table.Column<string>(nullable: false),
                    Atribuicao_Tipo = table.Column<string>(nullable: false),
                    Status_Valor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "identidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrimeiroNome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CPF_Digitos = table.Column<string>(nullable: false),
                    DataDeNascimento_Data = table.Column<DateTime>(nullable: false),
                    Telefone_Numero = table.Column<string>(nullable: true),
                    Celular_Numero = table.Column<string>(nullable: true),
                    Status_Valor = table.Column<bool>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    PerfilId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "identidade",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoAssinada",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status_Valor = table.Column<bool>(nullable: false),
                    PermissaoId = table.Column<Guid>(nullable: false),
                    PerfilId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoAssinada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissaoAssinada_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "identidade",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissaoAssinada_permissoes_PermissaoId",
                        column: x => x.PermissaoId,
                        principalSchema: "identidade",
                        principalTable: "permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_endereco",
                schema: "identidade",
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
                        principalSchema: "identidade",
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoAssinada_PerfilId",
                table: "PermissaoAssinada",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoAssinada_PermissaoId",
                table: "PermissaoAssinada",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_PerfilId",
                schema: "identidade",
                table: "usuarios",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissaoAssinada");

            migrationBuilder.DropTable(
                name: "usuario_endereco",
                schema: "identidade");

            migrationBuilder.DropTable(
                name: "permissoes",
                schema: "identidade");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "identidade");

            migrationBuilder.DropTable(
                name: "perfis",
                schema: "identidade");
        }
    }
}
