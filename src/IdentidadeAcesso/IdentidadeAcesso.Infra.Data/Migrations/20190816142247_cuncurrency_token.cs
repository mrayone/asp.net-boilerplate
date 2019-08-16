using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class cuncurrency_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "usuario_redefinicao_senha",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "usuario_redefinicao_senha",
                keyColumn: "UsuarioId",
                keyValue: new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("9148178c-ef6d-4971-a4b4-e481e427f453"));

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
    }
}
