namespace Basis.BibliotecaVirtual.Domain.Entities;

public class Livro_FormaCompra
{
    public int LivroCodL { get; set; }
    public Livro Livro { get; set; }
    public int FormaCompraCodFo { get; set; }
    public FormaCompra FormaCompra { get; set; }
    public decimal Preco { get; set; }
}
