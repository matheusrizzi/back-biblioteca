using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Assunto;

public class DeleteAssuntoCommand : IRequest<ApiResponse<bool>>
{
    public int CodAs { get; set; }
}
