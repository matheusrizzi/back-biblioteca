using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.FormaCompra;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.FormaCompra;

public class GetFormaCompraByIdQuery:IRequest<ApiResponse<GetFormaCompraResponse>>
{
    public int CodFo { get; set; }
}
