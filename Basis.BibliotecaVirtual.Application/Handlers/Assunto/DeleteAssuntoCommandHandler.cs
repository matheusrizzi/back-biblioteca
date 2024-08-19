using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using Basis.BibliotecaVirtual.Application.Queries.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Assunto;

public class DeleteAssuntoCommandHandler(IAssuntoRepository _repository, IMediator _mediator) : IRequestHandler<DeleteAssuntoCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteAssuntoCommand request, CancellationToken cancellationToken)
    {
        var getAssunto = await _mediator.Send(new GetAssuntoByIdQuery(request.CodAs));

        if (getAssunto.Result == null)
            return new ApiResponse<bool>() { Result = false, Error = getAssunto.Error };

        await _repository.DeleteAsync(getAssunto.Result);

        return new ApiResponse<bool>() { Result = true };
    }
}