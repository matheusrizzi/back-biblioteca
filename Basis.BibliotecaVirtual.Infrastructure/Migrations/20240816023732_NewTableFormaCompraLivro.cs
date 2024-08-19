using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTableFormaCompraLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Assunto_Assunto_AssuntoCodAs",
                table: "Livro_Assunto");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Assunto_Livro_LivroCodL",
                table: "Livro_Assunto");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_Autor_AutorCodAu",
                table: "Livro_Autor");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_Livro_LivroCodL",
                table: "Livro_Autor");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Assunto_Assunto_AssuntoCodAs",
                table: "Livro_Assunto",
                column: "AssuntoCodAs",
                principalTable: "Assunto",
                principalColumn: "CodAs",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Assunto_Livro_LivroCodL",
                table: "Livro_Assunto",
                column: "LivroCodL",
                principalTable: "Livro",
                principalColumn: "Codl",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_Autor_AutorCodAu",
                table: "Livro_Autor",
                column: "AutorCodAu",
                principalTable: "Autor",
                principalColumn: "CodAu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_Livro_LivroCodL",
                table: "Livro_Autor",
                column: "LivroCodL",
                principalTable: "Livro",
                principalColumn: "Codl",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Assunto_Assunto_AssuntoCodAs",
                table: "Livro_Assunto");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Assunto_Livro_LivroCodL",
                table: "Livro_Assunto");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_Autor_AutorCodAu",
                table: "Livro_Autor");

            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_Livro_LivroCodL",
                table: "Livro_Autor");

            migrationBuilder.DropTable(
                name: "FormaCompra_Livro");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Assunto_Assunto_AssuntoCodAs",
                table: "Livro_Assunto",
                column: "AssuntoCodAs",
                principalTable: "Assunto",
                principalColumn: "CodAs",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Assunto_Livro_LivroCodL",
                table: "Livro_Assunto",
                column: "LivroCodL",
                principalTable: "Livro",
                principalColumn: "Codl",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_Autor_AutorCodAu",
                table: "Livro_Autor",
                column: "AutorCodAu",
                principalTable: "Autor",
                principalColumn: "CodAu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_Livro_LivroCodL",
                table: "Livro_Autor",
                column: "LivroCodL",
                principalTable: "Livro",
                principalColumn: "Codl",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
