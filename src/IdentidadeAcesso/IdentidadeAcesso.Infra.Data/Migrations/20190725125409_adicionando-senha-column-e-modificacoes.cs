using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class adicionandosenhacolumnemodificacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF_Digitos",
                schema: "dbo",
                table: "usuarios",
                newName: "CPF");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                schema: "dbo",
                table: "usuarios",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                schema: "dbo",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "CPF",
                schema: "dbo",
                table: "usuarios",
                newName: "CPF_Digitos");
        }
    }
}
