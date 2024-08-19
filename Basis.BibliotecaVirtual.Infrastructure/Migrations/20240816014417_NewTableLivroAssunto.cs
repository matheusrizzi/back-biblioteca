using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableLivroAssunto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro_Assunto",
                columns: table => new
                {
                    LivroCodL = table.Column<int>(type: "int", nullable: false),
                    AssuntoCodAs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Assunto", x => new { x.LivroCodL, x.AssuntoCodAs });
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Assunto_AssuntoCodAs",
                        column: x => x.AssuntoCodAs,
                        principalTable: "Assunto",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_Livro_LivroCodL",
                        column: x => x.LivroCodL,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Assunto_AssuntoCodAs",
                table: "Livro_Assunto",
                column: "AssuntoCodAs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Assunto");
        }
    }
}
