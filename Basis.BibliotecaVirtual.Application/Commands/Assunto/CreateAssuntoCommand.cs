using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Commands.Assunto;

public class CreateAssuntoCommand : IRequest<ApiResponse<int>>
{
    public string Descricao { get; set; }
}