using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Autor;

public class CreateAutorCommand : IRequest<ApiResponse<int>>
{
    public string Nome { get; set; }
}
