using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class entidade_token_redefinicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario_redefinicao_senha",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("0a87780d-55da-4643-adef-bf07053389f3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("2f5d190d-adf4-4890-a15b-07a2c2ddca47"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("5dee7c85-7220-4262-835d-00feea2d4416"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("76da87df-88f8-4d60-8846-893d763f8bfb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("7e93bf5e-d13a-4e47-babb-2fd64a727bd1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("a54d7b26-4339-43b1-8649-eb44aaa2f987"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("d11c4be8-578b-4c45-a0a0-40de4495bca1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("d32e7c4e-08cf-4735-9e9d-2339735538b5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("d36aa882-fdc4-4769-8048-a14cdb576b97"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("d4c67f3e-7e06-4e7e-b9ed-6e3b55eaf08f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("dbb3f53f-9b14-4364-a9e0-6f1caec2e1af"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("e26710d0-3fbf-49a0-9f99-75e7611f5925"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("f1d8fbfd-99b6-4db9-a57e-8435de7d9b43"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("fae1b90b-714c-41e1-8b92-6612a3e7f083"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuario_endereco",
                keyColumn: "UsuarioId",
                keyValue: new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"));

            migrationBuilder.AddColumn<Guid>(
                name: "TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tokens_de_redefinicao",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens_de_redefinicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tokens_de_redefinicao_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("1c1beadf-50d1-4661-8356-b718a7e25b5c"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("cf73cd61-1c60-4e95-a097-d44d13905764"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("3d2bf605-57ef-48b3-8a41-2d43a3d193e0"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("16224ee5-e1fe-4f6c-bb1c-7efbb4272c80"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("60c96e0a-e3ca-4f78-89d4-6f0adf2b2db1"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("659daf03-ca68-4347-aced-bd2510853342"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("30bd7956-7241-4e67-b204-1b0b5cb8aa2d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("40641ca3-f164-4be9-95a6-271f7e4587d1"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("e09e3429-5cbd-4e5d-a911-a3d83df0f359"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("3f7f07ad-50cc-4fae-9494-325982fd2148"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("6a4fd3d0-2a45-467a-a566-8a481145f1be"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("53ee2af5-ae9a-474e-bc73-35239555d810"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("1c2853a5-20d1-4dae-a90d-2ab406e93876"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("ad1d0267-c1a9-4112-bf14-da13dd2eb921"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "TokenRedefinicaoSenhaId", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("fd79ad3a-d38d-45d5-8a8c-a2917365f6fd"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, null, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "APFL2AXM6AvPh4Wf3ooTxCexfSSEKVs929ZKiwU5YWiiVmMl1Evhgb22MCsq3qKAfQ==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_endereco",
                columns: new[] { "UsuarioId", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { new Guid("fd79ad3a-d38d-45d5-8a8c-a2917365f6fd"), null, null, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios",
                column: "TokenRedefinicaoSenhaId");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_de_redefinicao_UsuarioId",
                schema: "dbo",
                table: "tokens_de_redefinicao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_tokens_de_redefinicao_TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios",
                column: "TokenRedefinicaoSenhaId",
                principalSchema: "dbo",
                principalTable: "tokens_de_redefinicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_tokens_de_redefinicao_TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "tokens_de_redefinicao",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("16224ee5-e1fe-4f6c-bb1c-7efbb4272c80"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("1c1beadf-50d1-4661-8356-b718a7e25b5c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("1c2853a5-20d1-4dae-a90d-2ab406e93876"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("30bd7956-7241-4e67-b204-1b0b5cb8aa2d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("3d2bf605-57ef-48b3-8a41-2d43a3d193e0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("3f7f07ad-50cc-4fae-9494-325982fd2148"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("40641ca3-f164-4be9-95a6-271f7e4587d1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("53ee2af5-ae9a-474e-bc73-35239555d810"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("60c96e0a-e3ca-4f78-89d4-6f0adf2b2db1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("659daf03-ca68-4347-aced-bd2510853342"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("6a4fd3d0-2a45-467a-a566-8a481145f1be"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("ad1d0267-c1a9-4112-bf14-da13dd2eb921"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("cf73cd61-1c60-4e95-a097-d44d13905764"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("e09e3429-5cbd-4e5d-a911-a3d83df0f359"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuario_endereco",
                keyColumn: "UsuarioId",
                keyValue: new Guid("fd79ad3a-d38d-45d5-8a8c-a2917365f6fd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("fd79ad3a-d38d-45d5-8a8c-a2917365f6fd"));

            migrationBuilder.DropColumn(
                name: "TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios");

            migrationBuilder.CreateTable(
                name: "usuario_redefinicao_senha",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_redefinicao_senha", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_usuario_redefinicao_senha_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("d4c67f3e-7e06-4e7e-b9ed-6e3b55eaf08f"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("f1d8fbfd-99b6-4db9-a57e-8435de7d9b43"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("e26710d0-3fbf-49a0-9f99-75e7611f5925"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("0a87780d-55da-4643-adef-bf07053389f3"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("dbb3f53f-9b14-4364-a9e0-6f1caec2e1af"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("a54d7b26-4339-43b1-8649-eb44aaa2f987"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("fae1b90b-714c-41e1-8b92-6612a3e7f083"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("2f5d190d-adf4-4890-a15b-07a2c2ddca47"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("5dee7c85-7220-4262-835d-00feea2d4416"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("d32e7c4e-08cf-4735-9e9d-2339735538b5"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("d36aa882-fdc4-4769-8048-a14cdb576b97"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("d11c4be8-578b-4c45-a0a0-40de4495bca1"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("7e93bf5e-d13a-4e47-babb-2fd64a727bd1"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("76da87df-88f8-4d60-8846-893d763f8bfb"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "ALuR56IEZ6qZlXNgf61rXVOSbL+iJeUj5pJ09uPEy+DXpFn1UOVUgMTwAIYa9SB3+g==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_endereco",
                columns: new[] { "UsuarioId", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"), null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_redefinicao_senha",
                columns: new[] { "UsuarioId", "CriadoEm", "Token" },
                values: new object[] { new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"), null, null });
        }
    }
}
