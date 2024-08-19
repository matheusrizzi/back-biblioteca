using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Assunto;

public class UpdateAssuntoCommand : IRequest<ApiResponse<bool>>
{
    public int CodAs { get; set; }
    public string Descricao { get; set; }
}
