namespace Basis.BibliotecaVirtual.Domain.Entities;

public class Livro_Autor
{
    public int LivroCodL { get; set; }
    public Livro Livro { get; set; }
    public int AutorCodAu { get; set; }
    public Autor Autor { get; set; }
}
