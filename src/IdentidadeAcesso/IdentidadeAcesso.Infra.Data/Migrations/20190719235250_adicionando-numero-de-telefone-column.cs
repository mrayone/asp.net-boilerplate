using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentidadeAcesso.Infra.Data.Migrations
{
    public partial class adicionandonumerodetelefonecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                schema: "dbo",
                table: "usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                schema: "dbo",
                table: "usuarios");
        }
    }
}
