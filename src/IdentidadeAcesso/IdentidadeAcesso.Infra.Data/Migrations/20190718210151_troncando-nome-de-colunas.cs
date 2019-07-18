using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class troncandonomedecolunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone_Numero",
                schema: "dbo",
                table: "usuarios",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "Celular_Numero",
                schema: "dbo",
                table: "usuarios",
                newName: "Celular");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                schema: "dbo",
                table: "usuarios",
                newName: "Telefone_Numero");

            migrationBuilder.RenameColumn(
                name: "Celular",
                schema: "dbo",
                table: "usuarios",
                newName: "Celular_Numero");
        }
    }
}
