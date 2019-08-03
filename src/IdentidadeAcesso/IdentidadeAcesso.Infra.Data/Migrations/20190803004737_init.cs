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
                    CPF = table.Column<string>(nullable: true),
                    DataDeNascimento_Data = table.Column<DateTime>(nullable: false),
                    Celular = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    PerfilId = table.Column<Guid>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[] { new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), null, "Perfil de super usuário", "Administrador" });

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
                    { new Guid("10ee538c-01a1-4e41-8956-2b5fae573708"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("7caecebf-9522-4e88-9d08-85ba2797caec"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("e4cc37cb-10e6-4d85-9c7b-862a472115a5"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("de256069-fea2-4ecf-919d-245ffcda5ed4"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("41e7bea1-7a95-4cdb-acc7-4b4c80620cf1"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("414af151-1408-4ec6-b1a5-da2630989fa9"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("96a5e8ce-7432-4ccd-b733-6cfab29b4d32"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("563b8c28-58ff-4c0c-bb6d-9d98bc81ba5d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("36479f98-6616-4893-a621-9c4da228637d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("50b37aa3-cce4-41bf-b178-d1da4cfa5392"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("8ea60c9d-11c6-450d-a055-3ba269922a24"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("410eb828-8088-46fe-b046-09f3d0edac93"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("92950fb1-21ad-4dbd-89db-63d60300bbde"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("2b9306d8-c823-4080-a051-a92ffdcc3edb"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "AJCSz62DvWZLfooUaYj10vFYzwARYGBCpCx9CPQyoqNQtsphBev+ge2A5oK1lS1B2Q==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_endereco",
                columns: new[] { "UsuarioId", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { new Guid("bfdbdfc7-70c2-468f-bef5-fb82b67613fa"), null, null, null, null, null, null, null });

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
