namespace Basis.BibliotecaVirtual.Application.Responses.Reports;

public class GetLivrosPorAutorResponse
{
    public string NomeAutor { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public int AnoPublicacao { get; set; }
}