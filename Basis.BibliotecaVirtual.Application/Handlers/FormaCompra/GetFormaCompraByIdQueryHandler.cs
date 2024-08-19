using Basis.BibliotecaVirtual.Application.Queries.FormaCompra;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.FormaCompra;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.FormaCompra;

public class GetFormaCompraByIdQueryHandler(IFormaCompraRepository _repository) : IRequestHandler<GetFormaCompraByIdQuery, ApiResponse<GetFormaCompraResponse>>
{
    public async Task<ApiResponse<GetFormaCompraResponse>> Handle(GetFormaCompraByIdQuery request, CancellationToken cancellationToken)
    {
        var formaCompraResponse = await _repository.GetByIdAsync(request.CodFo);

        if (formaCompraResponse == null)
            return new ApiResponse<GetFormaCompraResponse>() { Error = new ErrorResult() { Message = "Forma de compra não encontrada." } };

        return new ApiResponse<GetFormaCompraResponse>()
        {
            Result = new GetFormaCompraResponse() { CodFo = formaCompraResponse.CodFo, Descricao = formaCompraResponse.Descricao }
        };
    }
}
