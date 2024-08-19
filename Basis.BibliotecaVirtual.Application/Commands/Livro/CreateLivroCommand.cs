using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Livro;

public class CreateLivroCommand : IRequest<ApiResponse<int>>
{
    public LivroCommand Livro { get; set; }
}

public class LivroCommand()
{
    public int CodL { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public int AnoPublicacao { get; set; }
    public IEnumerable<int> Assuntos { get; set; }
    public IEnumerable<int> Autores { get; set; }
    public IEnumerable<PrecoLivro> Precos { get; set; }
}

public class PrecoLivro()
{
    public int CodFo { get; set; }
    public decimal Preco { get; set; }
}
