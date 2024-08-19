using Basis.BibliotecaVirtual.Application.Responses;
using Model = Basis.BibliotecaVirtual.Domain.Entities;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Queries.Assunto;

public class GetAssuntoByIdQuery : IRequest<ApiResponse<Model.Assunto>>
{
    public int CodAs { get; }

    public GetAssuntoByIdQuery(int codAs)
    {
        CodAs = codAs;
    }
}
