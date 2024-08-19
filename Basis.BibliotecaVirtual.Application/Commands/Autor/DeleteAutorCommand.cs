using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Autor;

public class DeleteAutorCommand : IRequest<ApiResponse<bool>>
{
    public int CodAu { get; set; }
}