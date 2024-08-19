using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Reports;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.Reports;

public class GetLivrosPorAutorQuery : IRequest<ResponseEnumerable<GetLivrosPorAutorResponse>>
{
}
