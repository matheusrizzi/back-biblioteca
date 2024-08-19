using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableLivroAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro_Autor",
                columns: table => new
                {
                    LivroCodL = table.Column<int>(type: "int", nullable: false),
                    AutorCodAu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Autor", x => new { x.LivroCodL, x.AutorCodAu });
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Autor_AutorCodAu",
                        column: x => x.AutorCodAu,
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Livro_LivroCodL",
                        column: x => x.LivroCodL,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autor_AutorCodAu",
                table: "Livro_Autor",
                column: "AutorCodAu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Autor");
        }
    }
}
