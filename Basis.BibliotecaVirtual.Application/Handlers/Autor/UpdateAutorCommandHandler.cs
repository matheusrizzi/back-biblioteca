using Basis.BibliotecaVirtual.Application.Commands.Autor;
using Basis.BibliotecaVirtual.Application.Queries.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Autor;

public class UpdateAutorCommandHandler(IMediator _mediator, IAutorRepository _repository) : IRequestHandler<UpdateAutorCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
    {
        var getAutor = await _mediator.Send(new GetAutorByIdQuery(request.CodAu));

        if (getAutor.Result == null)
            return new ApiResponse<bool>() { Result = false, Error = getAutor.Error };

        var autor = getAutor.Result;
        autor.SetNome(request.Nome);

        await _repository.UpdateAsync(autor);

        return new ApiResponse<bool>() { Result = true };
    }
}
