using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Livro;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.Livro;

public class GetLivrosQuery:IRequest<ResponseEnumerable<GetLivrosQueryResponse>>
{
}