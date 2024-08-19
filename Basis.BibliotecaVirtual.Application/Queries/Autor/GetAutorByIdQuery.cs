using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.Autor;

public class GetAutorByIdQuery : IRequest<ApiResponse<Domain.Entities.Autor>>
{
    public int CodAu { get; }

    public GetAutorByIdQuery(int codAu)
    {
        CodAu = codAu;
    }
}
