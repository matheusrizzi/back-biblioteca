using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableLivroFormaCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormaCompra_Livro");

            migrationBuilder.CreateTable(
                name: "Livro_FormaCompra",
                columns: table => new
                {
                    LivroCodL = table.Column<int>(type: "int", nullable: false),
                    FormaCompraCodFo = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_FormaCompra", x => new { x.LivroCodL, x.FormaCompraCodFo });
                    table.ForeignKey(
                        name: "FK_Livro_FormaCompra_FormaCompra_FormaCompraCodFo",
                        column: x => x.FormaCompraCodFo,
                        principalTable: "FormaCompra",
                        principalColumn: "CodFo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livro_FormaCompra_Livro_LivroCodL",
                        column: x => x.LivroCodL,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_FormaCompra_FormaCompraCodFo",
                table: "Livro_FormaCompra",
                column: "FormaCompraCodFo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_FormaCompra");

            migrationBuilder.CreateTable(
                name: "FormaCompra_Livro",
                columns: table => new
                {
                    CodFo = table.Column<int>(type: "int", nullable: false),
                    CodL = table.Column<int>(type: "int", nullable: false),
                    ValorLivro = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaCompra_Livro", x => new { x.CodFo, x.CodL });
                    table.ForeignKey(
                        name: "FK_FormaCompra_Livro_FormaCompra_CodFo",
                        column: x => x.CodFo,
                        principalTable: "FormaCompra",
                        principalColumn: "CodFo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormaCompra_Livro_Livro_CodL",
                        column: x => x.CodL,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormaCompra_Livro_CodL",
                table: "FormaCompra_Livro",
                column: "CodL");
        }
    }
}
