using Basis.BibliotecaVirtual.Application.Queries.Livro;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Livro;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Livro;

public class GetLivrosQueryHandler(ILivroRepository _repository) : IRequestHandler<GetLivrosQuery, ResponseEnumerable<GetLivrosQueryResponse>>
{
    public async Task<ResponseEnumerable<GetLivrosQueryResponse>> Handle(GetLivrosQuery request, CancellationToken cancellationToken)
    {
        var livros = await _repository.GetAllAsync();

        var livroResponses = livros.Select(livro => new GetLivrosQueryResponse
        {
            Codl = livro.Codl,
            Titulo = livro.Titulo,
            Editora = livro.Editora,
            Edicao = livro.Edicao,
            AnoPublicacao = livro.AnoPublicacao,
            Autores = livro.LivrosAutores.Select(la => new AutorResponse
            {
                CodAu = la.Autor.CodAu,
                Nome = la.Autor.Nome
            }).ToList(),
            Assuntos = livro.LivrosAssuntos.Select(la => new AssuntoResponse
            {
                CodAs = la.Assunto.CodAs,
                Descricao = la.Assunto.Descricao
            }).ToList(),
            FormasCompra = livro.LivrosFormaCompras.Select(la => new LivroFormaCompraResponse
            {
                CodFo = la.FormaCompra.CodFo,
                Descricao = la.FormaCompra.Descricao,
                Preco = la.Preco
            }).ToList()
        }).ToList();

        return new ResponseEnumerable<GetLivrosQueryResponse>()
        {
            Result = livroResponses
        };
    }
}
