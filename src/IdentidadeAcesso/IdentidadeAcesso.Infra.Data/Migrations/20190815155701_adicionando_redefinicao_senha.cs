using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class adicionando_redefinicao_senha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("3f02bb54-e8db-4b08-9feb-51ef07cb033c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("4522b342-6037-43c3-8b39-f367cc17076a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("49c06af4-f0ae-420d-a5d3-09b6df4bfb02"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("4f0a7721-c50a-4df1-a1d6-61152f304d6f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("56e2f83e-eeb9-42f3-afeb-e8153ee17a5b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("5e27b13a-2e35-48f9-b3b0-c81930aba5ef"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("8656ddfb-4851-43a5-bfec-f3e51ab2f4fb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("8b7dd48d-fa14-462e-8a48-0c0a9eeb9115"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("92a02629-8f6e-43c9-a80e-db1fd7368bd8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("93d04dbd-cd3b-4bd1-a96b-c80ce11056f5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("a07dd0a4-60b7-45f1-9dbc-a7d4bf8d5f37"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("ab516ffa-d02a-4b0b-8a5f-2d0e02ec09e6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("b8ce11d0-f458-4437-a8fa-eaadff320da0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("e953547b-3ef7-4985-8e04-9e0a50b4e635"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuario_endereco",
                keyColumn: "UsuarioId",
                keyValue: new Guid("85a53c0f-7ece-40a2-a272-a03ce143406f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("85a53c0f-7ece-40a2-a272-a03ce143406f"));

            migrationBuilder.CreateTable(
                name: "usuario_redefinicao_senha",
                schema: "dbo",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true)
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
                    { new Guid("19f9177f-ab0f-43d1-9b0d-6dc0960e47ee"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("c05a518a-a61e-47dc-8613-037288a1b511"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("8407ee78-04a5-4241-ba83-a1f71cfcadbd"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("2283a005-390f-4324-b644-6512b6d96ba9"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("59268216-b077-4c7c-9bdf-61f2fe7f46b7"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("741a3595-1d0a-4519-9a88-c9308675167b"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("41bf2bd0-ad2f-427d-91fa-bd5eb550377d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("672a6f22-2d86-429c-841c-7b7cec482274"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("9a4f70a7-fe78-4890-85bd-0d1a55c58f1a"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("f5d6cc96-b44f-4c23-8f85-e8134ad30459"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("cc22f0cb-a240-450f-8687-9d3e0d9aac44"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("bbc9d3f7-47f9-4363-a437-2acbacf289a7"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("7e5b68ef-6336-4c4b-a5ae-c103fff2550d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("d3a6196c-5509-435d-8920-fc7b6fdf837d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("f083011c-aabd-415b-b64e-a1ea2ed69674"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "ALTP+hTva0spGIoj9oKeKwCVg6sUtKcXjbhqUKdmxBL4A0dyB4Oy8se6rmLwL9ZE7g==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_endereco",
                columns: new[] { "UsuarioId", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { new Guid("f083011c-aabd-415b-b64e-a1ea2ed69674"), null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_redefinicao_senha",
                columns: new[] { "UsuarioId", "CriadoEm", "Token" },
                values: new object[] { new Guid("f083011c-aabd-415b-b64e-a1ea2ed69674"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario_redefinicao_senha",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("19f9177f-ab0f-43d1-9b0d-6dc0960e47ee"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("2283a005-390f-4324-b644-6512b6d96ba9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("41bf2bd0-ad2f-427d-91fa-bd5eb550377d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("59268216-b077-4c7c-9bdf-61f2fe7f46b7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("672a6f22-2d86-429c-841c-7b7cec482274"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("741a3595-1d0a-4519-9a88-c9308675167b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("7e5b68ef-6336-4c4b-a5ae-c103fff2550d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("8407ee78-04a5-4241-ba83-a1f71cfcadbd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("9a4f70a7-fe78-4890-85bd-0d1a55c58f1a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("bbc9d3f7-47f9-4363-a437-2acbacf289a7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("c05a518a-a61e-47dc-8613-037288a1b511"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("cc22f0cb-a240-450f-8687-9d3e0d9aac44"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("d3a6196c-5509-435d-8920-fc7b6fdf837d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("f5d6cc96-b44f-4c23-8f85-e8134ad30459"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuario_endereco",
                keyColumn: "UsuarioId",
                keyValue: new Guid("f083011c-aabd-415b-b64e-a1ea2ed69674"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("f083011c-aabd-415b-b64e-a1ea2ed69674"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("4f0a7721-c50a-4df1-a1d6-61152f304d6f"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("b8ce11d0-f458-4437-a8fa-eaadff320da0"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("a07dd0a4-60b7-45f1-9dbc-a7d4bf8d5f37"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("92a02629-8f6e-43c9-a80e-db1fd7368bd8"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("e953547b-3ef7-4985-8e04-9e0a50b4e635"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("4522b342-6037-43c3-8b39-f367cc17076a"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("3f02bb54-e8db-4b08-9feb-51ef07cb033c"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("8656ddfb-4851-43a5-bfec-f3e51ab2f4fb"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("ab516ffa-d02a-4b0b-8a5f-2d0e02ec09e6"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("93d04dbd-cd3b-4bd1-a96b-c80ce11056f5"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("49c06af4-f0ae-420d-a5d3-09b6df4bfb02"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("8b7dd48d-fa14-462e-8a48-0c0a9eeb9115"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("5e27b13a-2e35-48f9-b3b0-c81930aba5ef"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("56e2f83e-eeb9-42f3-afeb-e8153ee17a5b"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("85a53c0f-7ece-40a2-a272-a03ce143406f"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "AINXYaqB+I+QcIA0E2xHq7N4H84CrXPkzoOmJQxf7XV2/mIiHa0xS8RbQOTcOJ6b3g==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_endereco",
                columns: new[] { "UsuarioId", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { new Guid("85a53c0f-7ece-40a2-a272-a03ce143406f"), null, null, null, null, null, null, null });
        }
    }
}
