using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Assuntos",
                table: "Assuntos");

            migrationBuilder.RenameTable(
                name: "Assuntos",
                newName: "Assunto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assunto",
                table: "Assunto",
                column: "CodAs");

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.CodAu);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assunto",
                table: "Assunto");

            migrationBuilder.RenameTable(
                name: "Assunto",
                newName: "Assuntos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assuntos",
                table: "Assuntos",
                column: "CodAs");
        }
    }
}
