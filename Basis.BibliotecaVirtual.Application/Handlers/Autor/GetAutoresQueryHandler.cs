using Basis.BibliotecaVirtual.Application.Queries.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Autor;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Autor;

public class GetAutoresQueryHandler(IAutorRepository _repository) : IRequestHandler<GetAutoresQuery, ResponseEnumerable<GetAutoresQueryResponse>>
{
    public async Task<ResponseEnumerable<GetAutoresQueryResponse>> Handle(GetAutoresQuery request, CancellationToken cancellationToken)
    {
        var autores = await _repository.GetAllAsync();

        var response = autores.Select(a => new GetAutoresQueryResponse()
        {
            CodAu = a.CodAu,
            Nome = a.Nome
        }).ToList();

        return new ResponseEnumerable<GetAutoresQueryResponse>()
        {
            Result = response
        };
    }
}
