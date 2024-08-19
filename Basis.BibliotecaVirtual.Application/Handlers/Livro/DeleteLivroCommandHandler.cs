using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Livro;

public class DeleteLivroCommandHandler(ILivroRepository _repository, 
                                       ILivro_AutorRepository _livroAutorRepository, 
                                       ILivro_AssuntoRepository _livroAssuntoRepository,
                                       ILivro_FormaCompraRepository _livroFormaCompraRepository,
                                       IMediator _mediator) : IRequestHandler<DeleteLivroCommand, ApiResponse<bool>>
                        
{
    public async Task<ApiResponse<bool>> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
    {
        var livro = await _repository.GetByIdAsync(request.CodL);

        if (livro == null)
            return new ApiResponse<bool>() { Result = false, Error = new ErrorResult() { Message = "Livro não encontrado." } };

        await RemoveAutoresLivro(_livroAutorRepository, request);
        await RemoveAssuntosLivro(_livroAssuntoRepository, request);
        await RemoverFormasCompraLivro(_livroFormaCompraRepository, request);

        await _repository.DeleteAsync(livro);

        return new ApiResponse<bool>() { Result = true };
    }

    private static async Task RemoverFormasCompraLivro(ILivro_FormaCompraRepository _livroFormaCompraRepository, DeleteLivroCommand request)
    {
        var formasCompra = await _livroFormaCompraRepository.GetByIdAsync(request.CodL);

        foreach (var item in formasCompra)
            await _livroFormaCompraRepository.DeleteAsync(item);
    }

    private static async Task RemoveAssuntosLivro(ILivro_AssuntoRepository _livroAssuntoRepository, DeleteLivroCommand request)
    {
        var assuntosLivro = await _livroAssuntoRepository.GetByIdAsync(request.CodL);

        foreach (var assunto in assuntosLivro)
            await _livroAssuntoRepository.DeleteAsync(assunto);
    }

    private static async Task RemoveAutoresLivro(ILivro_AutorRepository _livroAutorRepository, DeleteLivroCommand request)
    {
        var autoresLivro = await _livroAutorRepository.GetByIdAsync(request.CodL);

        foreach (var autor in autoresLivro)
            await _livroAutorRepository.DeleteAsync(autor);
    }
}
