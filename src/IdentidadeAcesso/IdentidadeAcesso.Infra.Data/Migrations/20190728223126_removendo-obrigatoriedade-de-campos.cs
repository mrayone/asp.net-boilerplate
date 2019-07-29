using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class removendoobrigatoriedadedecampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("01f51fa7-a5fa-4d67-a67d-1e5b23d22d52"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("27066fa7-3e59-4193-bcda-ec5bd2f73883"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("3588bbdc-a7a7-4318-a6e9-e21187a8e047"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("4b3adfec-ad5a-47bd-8fe0-f350fab1d6de"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("54ed99d1-7cf1-46a1-8523-36d9b3c90ae9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("580a232f-5297-42b2-a21e-c706fb54b515"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("5c5e6663-7396-4929-a872-d011f8bcf8d4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("9b7f7378-1d1b-4547-a0b2-240b58310450"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("a79f106f-05b9-4f13-9cac-501f0a8c757b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "permissoes_assinadas",
                keyColumn: "Id",
                keyValue: new Guid("c384a0fc-5748-4e75-862a-6fa4d9f60592"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("51ff5809-e464-45f6-81e4-682ab201b3bb"));

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

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                schema: "dbo",
                table: "usuarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                schema: "dbo",
                table: "usuarios",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                schema: "dbo",
                table: "usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                schema: "dbo",
                table: "usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "perfis",
                columns: new[] { "Id", "DeletadoEm", "Descricao", "Nome" },
                values: new object[] { new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), null, "Perfil de super usuário", "Super" });

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
                    { new Guid("4b3adfec-ad5a-47bd-8fe0-f350fab1d6de"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("c384a0fc-5748-4e75-862a-6fa4d9f60592"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("9b7f7378-1d1b-4547-a0b2-240b58310450"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("580a232f-5297-42b2-a21e-c706fb54b515"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("a79f106f-05b9-4f13-9cac-501f0a8c757b"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("54ed99d1-7cf1-46a1-8523-36d9b3c90ae9"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("3588bbdc-a7a7-4318-a6e9-e21187a8e047"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("01f51fa7-a5fa-4d67-a67d-1e5b23d22d52"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("5c5e6663-7396-4929-a872-d011f8bcf8d4"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("27066fa7-3e59-4193-bcda-ec5bd2f73883"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("51ff5809-e464-45f6-81e4-682ab201b3bb"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "maycon.rayone@gmail.com", "Maycon Rayone", "Rodrigues Xavier", null, null, "AA/mq7/o0FzgHhO/xE4+rJ1tO6JKmiZYxe9c7SjI6LI1j6aDxDhcNjbznfrsTU3y3g==", "Masculino" });
        }
    }
}
