using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Livro;

public class DeleteLivroCommand : IRequest<ApiResponse<bool>>
{
    public int CodL { get; set; }
}
