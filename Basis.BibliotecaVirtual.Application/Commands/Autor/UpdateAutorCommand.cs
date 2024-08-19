using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Autor;

public class UpdateAutorCommand : IRequest<ApiResponse<bool>>
{
    public int CodAu { get; set; }
    public string Nome { get; set; }
}
