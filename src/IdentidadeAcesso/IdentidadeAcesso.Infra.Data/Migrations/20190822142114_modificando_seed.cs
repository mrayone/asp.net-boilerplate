using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class modificando_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_tokens_de_redefinicao_TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios");

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                columns: new[] { "Id", "PerfilId", "PermissaoId", "Ativo" },
                values: new object[,]
                {
                    { new Guid("71ef947d-2f1d-47de-b651-6c2ffd0c9ee4"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("4cf679e7-ef92-49e4-b677-2ec8d4e91453"), true },
                    { new Guid("17cb75eb-177a-424d-91d7-18ff251408f5"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("99e90c66-a791-42d6-a24a-f4bc1235a576"), true },
                    { new Guid("29cfa08b-d1fd-48ed-9b96-fa249e0e1285"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("20f04a05-7732-428c-a5f2-1a5765256808"), true },
                    { new Guid("1c181735-a7be-4ed3-83d9-eaf2de07fb41"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f40ed114-8191-4621-8836-21aaf60eecf4"), true },
                    { new Guid("aa843f65-f247-43b1-a856-ff0276f0d359"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("0440c348-12c2-435a-a027-f81636e71faa"), true },
                    { new Guid("692b5b0d-5f72-41cb-80f8-99f5a930adcc"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("1503b73e-4db3-4122-ac1f-b8ce7a0214ee"), true },
                    { new Guid("5643bffb-2c44-4e21-b410-fe10fc011b35"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("170a49c2-5f0f-4552-b8cc-bf679e96bcbe"), true },
                    { new Guid("aafdd070-d1ac-4fe8-94b5-5511d9d9c6a2"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("cec6f99f-4c3f-483c-ba53-954d79a553e0"), true },
                    { new Guid("ff2f1b56-dea9-47ca-b9fe-8bf7159f94d2"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("fc7cc8f8-0fd8-4067-ba34-f8c06e02f57c"), true },
                    { new Guid("5cd49434-923a-4a8a-8e76-f3abb20032f7"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("f2c056c9-9320-492e-9d6a-563bd5788a8a"), true },
                    { new Guid("119059ec-ae7e-4104-81c3-b3988b9d4bb2"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("e8d085f3-ebc1-4bc1-83c7-1cdc41d3dc49"), true },
                    { new Guid("a75234d8-eccc-4490-a45d-7cf97e5ceebc"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("bc6e96ae-c6af-40ca-8c11-cd11fb8a3e27"), true },
                    { new Guid("5a0b362f-af22-43a3-9a1b-74dc4cad85e4"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("9f688e0a-a29f-4713-be45-c2a25df474b1"), true },
                    { new Guid("623e2781-1a60-4367-9ae6-294570053f47"), new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), new Guid("a6eb8dd5-cfe6-4154-8a29-f3cf66dc5cd0"), true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "Id", "DeletadoEm", "PerfilId", "Status", "CPF", "DataDeNascimento_Data", "Email", "PrimeiroNome", "Sobrenome", "Celular", "Telefone", "Senha", "Sexo" },
                values: new object[] { new Guid("2b630a43-a4bc-4673-8bfc-e81e2eb6b89b"), null, new Guid("8cd6c8ca-7db7-4551-b6c5-f7a724286709"), true, "28999953084", new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminfake@mozej.com", "Admin", "Fake", null, null, "ABVrq8U9AvkSPMDrPsFcL8ZtINCALRi3S8lYCOpFJ/rSGdec96oOqy6uNT6QybcalQ==", "Masculino" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuario_endereco",
                columns: new[] { "UsuarioId", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { new Guid("2b630a43-a4bc-4673-8bfc-e81e2eb6b89b"), null, null, null, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("119059ec-ae7e-4104-81c3-b3988b9d4bb2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("17cb75eb-177a-424d-91d7-18ff251408f5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("1c181735-a7be-4ed3-83d9-eaf2de07fb41"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("29cfa08b-d1fd-48ed-9b96-fa249e0e1285"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("5643bffb-2c44-4e21-b410-fe10fc011b35"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("5a0b362f-af22-43a3-9a1b-74dc4cad85e4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("5cd49434-923a-4a8a-8e76-f3abb20032f7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("623e2781-1a60-4367-9ae6-294570053f47"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("692b5b0d-5f72-41cb-80f8-99f5a930adcc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("71ef947d-2f1d-47de-b651-6c2ffd0c9ee4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("a75234d8-eccc-4490-a45d-7cf97e5ceebc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("aa843f65-f247-43b1-a856-ff0276f0d359"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("aafdd070-d1ac-4fe8-94b5-5511d9d9c6a2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "atribuicoes_perfil",
                keyColumn: "Id",
                keyValue: new Guid("ff2f1b56-dea9-47ca-b9fe-8bf7159f94d2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuario_endereco",
                keyColumn: "UsuarioId",
                keyValue: new Guid("2b630a43-a4bc-4673-8bfc-e81e2eb6b89b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "Id",
                keyValue: new Guid("2b630a43-a4bc-4673-8bfc-e81e2eb6b89b"));

            migrationBuilder.AddColumn<Guid>(
                name: "TokenRedefinicaoSenhaId",
                schema: "dbo",
                table: "usuarios",
                nullable: true);

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
    }
}
