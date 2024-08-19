using Basis.BibliotecaVirtual.Application.Queries.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Autor;

public class GetAutorByIdQueryHandler(IAutorRepository _repository) : IRequestHandler<GetAutorByIdQuery, ApiResponse<Domain.Entities.Autor>>
{
    public async Task<ApiResponse<Domain.Entities.Autor>> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
    {
        var autor = await _repository.GetByIdAsync(request.CodAu);

        if (autor == null)
            return new ApiResponse<Domain.Entities.Autor>() { Result = null, Error = new ErrorResult() { Message = $"Não foi possível encontrar o autor {request.CodAu}." } };

        return new ApiResponse<Domain.Entities.Autor>() { Result = autor };
    }
}