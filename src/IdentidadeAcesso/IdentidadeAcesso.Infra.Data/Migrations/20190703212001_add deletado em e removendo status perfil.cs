using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class adddeletadoemeremovendostatusperfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status_Valor",
                schema: "identidade",
                table: "permissoes");

            migrationBuilder.DropColumn(
                name: "Status_Valor",
                schema: "identidade",
                table: "perfis");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletadoEm",
                schema: "identidade",
                table: "permissoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletadoEm",
                schema: "identidade",
                table: "permissoes");

            migrationBuilder.AddColumn<bool>(
                name: "Status_Valor",
                schema: "identidade",
                table: "permissoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status_Valor",
                schema: "identidade",
                table: "perfis",
                nullable: false,
                defaultValue: false);
        }
    }
}
