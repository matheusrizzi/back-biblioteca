using Basis.BibliotecaVirtual.Application.Commands.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;
using Models = Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Application.Handlers.Autor;

public class CreateAutorCommandHandler(IAutorRepository _repository) : IRequestHandler<CreateAutorCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = Models.Autor.Create(request.Nome);

        await _repository.AddAsync(autor);

        return new ApiResponse<int>()
        {
            Result = autor.CodAu
        };
    }
}
