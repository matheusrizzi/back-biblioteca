using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Assunto;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.Assunto;

public class GetAssuntosQuery : IRequest<ResponseEnumerable<GetAssuntosQueryResponse>>
{
}