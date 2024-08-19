using Basis.BibliotecaVirtual.Application.Commands.Autor;
using Basis.BibliotecaVirtual.Application.Queries.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Autor;

public class DeleteAutorCommandHandler(IAutorRepository _repository, IMediator _mediator) : IRequestHandler<DeleteAutorCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
    {
        var getAutor = await _mediator.Send(new GetAutorByIdQuery(request.CodAu));

        if (getAutor.Result == null)
            return new ApiResponse<bool>() { Result = false, Error = getAutor.Error };

        await _repository.DeleteAsync(getAutor.Result);

        return new ApiResponse<bool>() { Result = true };
    }
}
