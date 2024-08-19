using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using Models = Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Assunto;

public class CreateAssuntoCommandHandler(IAssuntoRepository _repository) : IRequestHandler<CreateAssuntoCommand, ApiResponse<int>>
{
    //private readonly IAssuntoRepository _repository;
    //private readonly IValidator<CreateAssuntoCommand> _validator;

    //public CreateAssuntoCommandHandler(IAssuntoRepository repository, IValidator<CreateAssuntoCommand> validator)
    //{
    //    _repository = repository;
    //    _validator = validator;
    //}

    public async Task<ApiResponse<int>> Handle(CreateAssuntoCommand request, CancellationToken cancellationToken)
    {
        var assunto = Models.Assunto.Create(request.Descricao);

        await _repository.AddAsync(assunto);

        return new ApiResponse<int>()
        {
            Result = assunto.CodAs
        };
    }
}