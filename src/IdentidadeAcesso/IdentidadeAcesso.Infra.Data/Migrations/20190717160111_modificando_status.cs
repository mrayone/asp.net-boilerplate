using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class modificando_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_assinadas_perfis_PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas");

            migrationBuilder.RenameColumn(
                name: "Status_Valor",
                schema: "dbo",
                table: "permissoes_assinadas",
                newName: "Ativo");

            migrationBuilder.AlterColumn<Guid>(
                name: "PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_assinadas_perfis_PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas",
                column: "PerfilId",
                principalSchema: "dbo",
                principalTable: "perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_assinadas_perfis_PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                schema: "dbo",
                table: "permissoes_assinadas",
                newName: "Status_Valor");

            migrationBuilder.AlterColumn<Guid>(
                name: "PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_assinadas_perfis_PerfilId",
                schema: "dbo",
                table: "permissoes_assinadas",
                column: "PerfilId",
                principalSchema: "dbo",
                principalTable: "perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
