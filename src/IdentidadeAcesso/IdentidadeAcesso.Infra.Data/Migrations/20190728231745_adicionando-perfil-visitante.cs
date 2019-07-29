using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class adicionandoperfilvisitante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), null, "Perfil", "Desativar Permissões" },
                    { new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), null, "Perfil", "Atribuir Permissões" },
                    { new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), null, "Perfil", "Criar Perfil" },
                    { new Guid("0440c348-12c2-435a-a027-f81636e71faa"), null, "Perfil", "Editar Perfil" },
                    { new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), null, "Perfil", "Excluir Perfil" },
                    { new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), null, "Permissão", "Criar Permissão" },
                    { new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), null, "Permissão", "Editar Permissão" },
                    { new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), null, "Permissão", "Visualizar Permissões" },
                    { new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), null, "Permissão", "Excluir Permissão" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "perfis",
                keyColumn: "Id",
                keyValue: new Guid("21dae14c-632b-4768-bfab-722bd291c785"));

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

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "perfis",
                keyColumn: "Id",
                keyValue: new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("0440c348-12c2-435a-a027-f81636e71faa"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("20f04a05-7732-428c-a5f2-1a5765256808"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes",
                keyColumn: "Id",
                keyValue: new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"));
        }
    }
}
