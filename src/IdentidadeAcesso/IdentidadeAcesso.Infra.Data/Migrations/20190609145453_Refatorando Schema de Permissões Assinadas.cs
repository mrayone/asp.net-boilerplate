using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class RefatorandoSchemadePermissõesAssinadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoAssinada_perfis_PerfilId",
                table: "PermissaoAssinada");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoAssinada_permissoes_PermissaoId",
                table: "PermissaoAssinada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissaoAssinada",
                table: "PermissaoAssinada");

            migrationBuilder.RenameTable(
                name: "PermissaoAssinada",
                newName: "permissoes_assinadas",
                newSchema: "identidade");

            migrationBuilder.RenameIndex(
                name: "IX_PermissaoAssinada_PermissaoId",
                schema: "identidade",
                table: "permissoes_assinadas",
                newName: "IX_permissoes_assinadas_PermissaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissaoAssinada_PerfilId",
                schema: "identidade",
                table: "permissoes_assinadas",
                newName: "IX_permissoes_assinadas_PerfilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissoes_assinadas",
                schema: "identidade",
                table: "permissoes_assinadas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_assinadas_perfis_PerfilId",
                schema: "identidade",
                table: "permissoes_assinadas",
                column: "PerfilId",
                principalSchema: "identidade",
                principalTable: "perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_assinadas_permissoes_PermissaoId",
                schema: "identidade",
                table: "permissoes_assinadas",
                column: "PermissaoId",
                principalSchema: "identidade",
                principalTable: "permissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_assinadas_perfis_PerfilId",
                schema: "identidade",
                table: "permissoes_assinadas");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_assinadas_permissoes_PermissaoId",
                schema: "identidade",
                table: "permissoes_assinadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissoes_assinadas",
                schema: "identidade",
                table: "permissoes_assinadas");

            migrationBuilder.RenameTable(
                name: "permissoes_assinadas",
                schema: "identidade",
                newName: "PermissaoAssinada");

            migrationBuilder.RenameIndex(
                name: "IX_permissoes_assinadas_PermissaoId",
                table: "PermissaoAssinada",
                newName: "IX_PermissaoAssinada_PermissaoId");

            migrationBuilder.RenameIndex(
                name: "IX_permissoes_assinadas_PerfilId",
                table: "PermissaoAssinada",
                newName: "IX_PermissaoAssinada_PerfilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissaoAssinada",
                table: "PermissaoAssinada",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoAssinada_perfis_PerfilId",
                table: "PermissaoAssinada",
                column: "PerfilId",
                principalSchema: "identidade",
                principalTable: "perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoAssinada_permissoes_PermissaoId",
                table: "PermissaoAssinada",
                column: "PermissaoId",
                principalSchema: "identidade",
                principalTable: "permissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
