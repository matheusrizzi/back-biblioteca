using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;
using Qry = Basis.BibliotecaVirtual.Application.Queries.Assunto;

namespace Basis.BibliotecaVirtual.Application.Handlers.Assunto;

public class UpdateAssuntoCommandHandler : IRequestHandler<UpdateAssuntoCommand, ApiResponse<bool>>
{
    private readonly IAssuntoRepository _assuntoRepository;
    private readonly IMediator _mediator;

    public UpdateAssuntoCommandHandler(IAssuntoRepository assuntoRepository, IMediator mediator)
    {
        _assuntoRepository = assuntoRepository;
        _mediator = mediator;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateAssuntoCommand request, CancellationToken cancellationToken)
    {
        var getAssunto = await _mediator.Send(new Qry.GetAssuntoByIdQuery(request.CodAs));

        if (getAssunto.Result == null)
            return new ApiResponse<bool>() { Result = false, Error = getAssunto.Error };

        var assunto = getAssunto.Result;
        assunto.SetDescricao(request.Descricao);

        await _assuntoRepository.UpdateAsync(assunto);

        return new ApiResponse<bool>() { Result = true };
    }
}
