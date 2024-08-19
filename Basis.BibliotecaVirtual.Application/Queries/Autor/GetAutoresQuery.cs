using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Autor;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.Autor;

public class GetAutoresQuery : IRequest<ResponseEnumerable<GetAutoresQueryResponse>>
{
}
