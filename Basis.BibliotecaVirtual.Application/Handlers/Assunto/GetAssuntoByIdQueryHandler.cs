using Basis.BibliotecaVirtual.Application.Responses;
using Model = Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;
using Basis.BibliotecaVirtual.Application.Queries.Assunto;


namespace Basis.BibliotecaVirtual.Application.Handlers.Assunto;

public class GetAssuntoByIdQueryHandler : IRequestHandler<GetAssuntoByIdQuery, ApiResponse<Model.Assunto>>
{
    private IAssuntoRepository _repository;

    public GetAssuntoByIdQueryHandler(IAssuntoRepository repository) => _repository = repository;

    public async Task<ApiResponse<Model.Assunto>> Handle(GetAssuntoByIdQuery request, CancellationToken cancellationToken)
    {
        var assunto = await _repository.GetByIdAsync(request.CodAs);

        if (assunto == null)
            return new ApiResponse<Model.Assunto>() { Result = null, Error = new ErrorResult() { Message = $"Não foi possível encontrar o assunto de número {request.CodAs}." } };

        return new ApiResponse<Model.Assunto>() { Result = assunto };
    }
}