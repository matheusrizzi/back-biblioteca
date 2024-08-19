namespace Basis.BibliotecaVirtual.Application.Responses.Livro;

public class GetLivrosQueryResponse
{
    public int Codl { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public int AnoPublicacao { get; set; }
    public List<AutorResponse> Autores { get; set; }
    public List<AssuntoResponse> Assuntos { get; set; }
    public List<LivroFormaCompraResponse> FormasCompra { get; set; }
}

public class AutorResponse
{
    public int CodAu { get; set; }
    public string Nome { get; set; }
}

public class AssuntoResponse
{
    public int CodAs { get; set; }
    public string Descricao { get; set; }
}

public class LivroFormaCompraResponse
{
    public int CodFo { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
}