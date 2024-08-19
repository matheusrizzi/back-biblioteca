using Basis.BibliotecaVirtual.Application.Queries.Reports;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Reports;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Reports;

public class GetLivrosPorAutorQueryHandler(ILivrosPorAutorViewRepository _repository) : IRequestHandler<GetLivrosPorAutorQuery, ResponseEnumerable<GetLivrosPorAutorResponse>>
{
    public async Task<ResponseEnumerable<GetLivrosPorAutorResponse>> Handle(GetLivrosPorAutorQuery request, CancellationToken cancellationToken)
    {
        var livrosPorAutor = await _repository.GetAllAsync();

        var response = livrosPorAutor.OrderBy(x=>x.NomeAutor)
                                     .Select(a => new GetLivrosPorAutorResponse()
        {
            NomeAutor = a.NomeAutor,
            AnoPublicacao = a.AnoPublicacao,
            Titulo = a.Titulo,
            Edicao = a.Edicao,
            Editora = a.Editora
        }).ToList();

        return new ResponseEnumerable<GetLivrosPorAutorResponse>()
        {
            Result = response
        };
    }
}
