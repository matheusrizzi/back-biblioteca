using Basis.BibliotecaVirtual.Application.Builder;
using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Livro;

public class CreateLivroCommandHandler : LivroHandlerBase, IRequestHandler<CreateLivroCommand, ApiResponse<int>>
{
    private ILivroRepository _livroRepository;

    public CreateLivroCommandHandler(ILivroRepository livroRepository, 
                                     IAssuntoRepository assuntoRepository,
                                     IAutorRepository autorRepository,
                                     IFormaCompraRepository formaCompraRepository) : base(assuntoRepository, autorRepository, formaCompraRepository)
    {
        this._livroRepository = livroRepository;
    }


    public async Task<ApiResponse<int>> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
    {
        var assuntos = await GetAssuntosLivro(request.Livro.Assuntos);
        var autores = await GetAutoresLivro(request.Livro.Autores);
        var formasCompra = await GetFormasCompraLivro(request.Livro.Precos);

        var livro = new CreateLivroBuilder(request)
                            .AddAssuntos(assuntos)
                            .AddAutores(autores)
                            .AddFormasCompra(formasCompra)
                            .Build();

        await _livroRepository.AddAsync(livro);

        return new ApiResponse<int>() { Result = livro.Codl };
    }
}
