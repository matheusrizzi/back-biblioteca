using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using MediatR;

namespace Basis.BibliotecaVirtual.Application.Handlers.Livro;

public class UpdateLivroCommandHandler : LivroHandlerBase, IRequestHandler<UpdateLivroCommand, ApiResponse<bool>>
{
    private ILivroRepository _livroRepository;

    public UpdateLivroCommandHandler(ILivroRepository livroRepository, 
                                     IAssuntoRepository assuntoRepository, 
                                     IAutorRepository autorRepository, 
                                     IFormaCompraRepository formaCompraRepository) : base(assuntoRepository, autorRepository, formaCompraRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
    {
        var livro = await _livroRepository.GetByIdAsync(request.CodL);

        if (livro == null)
            throw new Exception("Livro não encontrado.");

        livro.Titulo = request.Titulo;
        livro.Editora = request.Editora;
        livro.Edicao = request.Edicao;
        livro.AnoPublicacao = request.AnoPublicacao;

        livro.LivrosAssuntos.Clear();
        livro.LivrosAutores.Clear();
        livro.LivrosFormaCompras.Clear();

        var assuntos = await GetAssuntosLivro(request.Assuntos);
        var autores = await GetAutoresLivro(request.Autores);
        var formasCompra = await GetFormasCompraLivro(request.Precos);

        AdicionarAutores(livro, autores);
        AdicionarAssuntos(livro, assuntos);
        AdicionarFormasCompra(livro, formasCompra, request.Precos);

        await _livroRepository.UpdateAsync(livro);

        return new ApiResponse<bool>() { Result = true };
    }

    private static void AdicionarAutores(Domain.Entities.Livro? livro, IEnumerable<Domain.Entities.Autor> autores)
    {
        foreach (var autor in autores)
        {
            livro.LivrosAutores.Add(new Livro_Autor
            {
                Autor = autor,
                Livro = livro
            });
        }
    }

    private static void AdicionarAssuntos(Domain.Entities.Livro? livro, IEnumerable<Domain.Entities.Assunto> assuntos)
    {
        foreach (var assunto in assuntos)
        {
            livro.LivrosAssuntos.Add(new Livro_Assunto
            {
                Assunto = assunto,
                Livro = livro
            });
        }
    }

    private static void AdicionarFormasCompra(Domain.Entities.Livro? livro, IEnumerable<Domain.Entities.FormaCompra> formasCompra, IEnumerable<PrecoLivro> precos)
    {
        foreach (var formaCompra in formasCompra)
        {
            var price = precos.FirstOrDefault(x => x.CodFo == formaCompra.CodFo);

            livro.LivrosFormaCompras.Add(new Livro_FormaCompra
            {
                FormaCompra = formaCompra,
                Livro = livro,
                Preco = price == null ? 0 : price.Preco
            });
        }
    }
}
