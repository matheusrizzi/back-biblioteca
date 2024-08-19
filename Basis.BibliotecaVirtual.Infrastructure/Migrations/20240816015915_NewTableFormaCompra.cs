using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableFormaCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaCompra",
                columns: table => new
                {
                    CodFo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaCompra", x => x.CodFo);
                });

            migrationBuilder.InsertData(
                table: "FormaCompra",
                columns: new[] { "CodFo", "Descricao" },
                values: new object[,]
                {
                    { 1, "Balcão" },
                    { 2, "Self-Service" },
                    { 3, "Internet" },
                    { 4, "Evento" },
                    { 5, "Outros" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormaCompra");
        }
    }
}
