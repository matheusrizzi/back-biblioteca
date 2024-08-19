using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.FormaCompra;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.FormaCompra;

public class GetAllFormaCompraQuery : IRequest<ResponseEnumerable<GetFormaCompraResponse>>
{
}
