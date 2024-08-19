using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Livro;

public class UpdateLivroCommand: LivroCommand, IRequest<ApiResponse<bool>>
{
}
