using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class adicionandonovaspermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("1beee85d-efb0-47c6-ace1-553497e98fb6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("206db8b4-ff01-43d8-b8ce-15f4e2d43669"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("442f0b42-4c29-40f9-82e4-4276edbbaf1e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("5f1c42bb-40fa-4e43-bd47-d2e8488c221b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("88430ee5-a2a0-4570-86dc-ff437e63f12f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("8fae4998-11a3-4830-abcb-8ca17ef83e51"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("9e591cc7-525b-4e14-b99a-e123b21be278"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("b5983e08-0bcc-4e00-94ec-3839188d6958"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("f0c80a74-3f8f-47a0-872b-907f54c7d546"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("fc3d1987-175c-4ff6-a0a4-cc0403d1855d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("611a2634-08f7-4688-a51e-f094b00272c4"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"),
                column: "Atribuicao_Valor",
                value: "Revogar Permissões");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes",
                columns: new[] { "Id", "DeletadoEm", "Atribuicao_Tipo", "Atribuicao_Valor" },
                values: new object[,]
                {
                    { new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), null, "Usuário", "Visualizar Usuários" },
                    { new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), null, "Usuário", "Criar Usuário" },
                    { new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), null, "Usuário", "Atualizar Usuário" },
                    { new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), null, "Usuário", "Excluir Usuário" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes_assinadas",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("e7805dc3-4467-4419-919b-c92ae8f73503"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("45264d36-357b-49c5-bf4b-9e912822ce53"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("aa05a5a5-eec8-402e-be42-caad33699bcf"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("d9d1a1ae-319f-4c54-b922-f00fbe511c9e"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("b6da9b30-7492-41c8-a47a-f85dbc6e1fd3"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("c5c7a580-7fd0-4352-8679-e73f1e30c1c4"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("c7de425f-7f9d-4f06-b2ce-890c557e4f46"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("642b35bb-e3b8-4429-8caf-4551d8553262"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("d37eaa37-7545-4c98-8f9d-3b2e1c09711e"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("d45bc024-bcf7-489f-bc9a-eff7fb285bd8"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("765163e0-f5bd-4330-9719-81b904ad41b1"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "AC0GULpVoBzGMGbmubJr5f1STDS9AA/YCHH24gaAsWzXhKittZaD6uvrrMTcaxCUyQ==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes_assinadas",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("32c8aa3c-21bd-4be5-b04a-183b4bf09d3d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("d6823ab6-3575-4766-8118-e06ed9383f6e"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("4f1d0fd8-994a-496d-b18c-8e6c777e42b2"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("0837d867-b6d2-4d7d-9790-d3ee21095579"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("0837d867-b6d2-4d7d-9790-d3ee21095579"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("32c8aa3c-21bd-4be5-b04a-183b4bf09d3d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("45264d36-357b-49c5-bf4b-9e912822ce53"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("4f1d0fd8-994a-496d-b18c-8e6c777e42b2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("642b35bb-e3b8-4429-8caf-4551d8553262"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("aa05a5a5-eec8-402e-be42-caad33699bcf"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("b6da9b30-7492-41c8-a47a-f85dbc6e1fd3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("c5c7a580-7fd0-4352-8679-e73f1e30c1c4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("c7de425f-7f9d-4f06-b2ce-890c557e4f46"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("d37eaa37-7545-4c98-8f9d-3b2e1c09711e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("d45bc024-bcf7-489f-bc9a-eff7fb285bd8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("d6823ab6-3575-4766-8118-e06ed9383f6e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("d9d1a1ae-319f-4c54-b922-f00fbe511c9e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("e7805dc3-4467-4419-919b-c92ae8f73503"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("765163e0-f5bd-4330-9719-81b904ad41b1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"),
                column: "Atribuicao_Valor",
                value: "Desativar Permissões");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "permissoes_assinadas",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("fc3d1987-175c-4ff6-a0a4-cc0403d1855d"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("b5983e08-0bcc-4e00-94ec-3839188d6958"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("8fae4998-11a3-4830-abcb-8ca17ef83e51"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("1beee85d-efb0-47c6-ace1-553497e98fb6"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("88430ee5-a2a0-4570-86dc-ff437e63f12f"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("5f1c42bb-40fa-4e43-bd47-d2e8488c221b"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("f0c80a74-3f8f-47a0-872b-907f54c7d546"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("9e591cc7-525b-4e14-b99a-e123b21be278"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("206db8b4-ff01-43d8-b8ce-15f4e2d43669"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("442f0b42-4c29-40f9-82e4-4276edbbaf1e"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("611a2634-08f7-4688-a51e-f094b00272c4"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "maycon.rayone@gmail.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "AFdreHvQQn0uKAPgf7Y443HW4vwmK9oTun/k2ACddiDdYDFHE/cIZ7Rvsyo3U6ppkg==", "Masculino" });
        }
    }
}
