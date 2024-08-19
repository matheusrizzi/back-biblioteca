using Basis.BibliotecaVirtual.Application.Queries.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Assunto;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Assunto;

public class GetAssuntosQueryHandler(IAssuntoRepository _repository) : IRequestHandler<GetAssuntosQuery, ResponseEnumerable<GetAssuntosQueryResponse>>
{
    public async Task<ResponseEnumerable<GetAssuntosQueryResponse>> Handle(GetAssuntosQuery request, CancellationToken cancellationToken)
    {
        var assuntos = await _repository.GetAllAsync();

        var response = assuntos.Select(a => new GetAssuntosQueryResponse()
        {
            CodAs = a.CodAs,
            Descricao = a.Descricao
        }).ToList();

        return new ResponseEnumerable<GetAssuntosQueryResponse>()
        {
            Result = response
        };
    }
}
