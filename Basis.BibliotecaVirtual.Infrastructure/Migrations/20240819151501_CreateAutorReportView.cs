using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basis.BibliotecaVirtual.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAutorReportView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW LivrosPorAutorView as
                                        SELECT a.nome as nomeautor, l.titulo, l.editora, l.edicao, l.anopublicacao
                                          FROM dbo.livro_autor la
                                          INNER JOIN dbo.autor a on a.codau = la.autorcodau
                                          INNER JOIN dbo.livro l on l.codl = la.livrocodl;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW LivrosPorAutorView;");
        }
    }
}
