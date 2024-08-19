using Basis.BibliotecaVirtual.Application.Queries.FormaCompra;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.FormaCompra;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.FormaCompra;

public class GetAllFormaCompraQueryHandler (IFormaCompraRepository _repository) : IRequestHandler<GetAllFormaCompraQuery, ResponseEnumerable<GetFormaCompraResponse>>
{
    public  async Task<ResponseEnumerable<GetFormaCompraResponse>> Handle(GetAllFormaCompraQuery request, CancellationToken cancellationToken)
    {
        var formaCompraResponse = await _repository.GetAllAsync();

        var response = formaCompraResponse.Select(a => new GetFormaCompraResponse()
        {
            CodFo = a.CodFo,
            Descricao = a.Descricao
        }).ToList();

        return new ResponseEnumerable<GetFormaCompraResponse>()
        {
            Result = response
        };
    }
}
