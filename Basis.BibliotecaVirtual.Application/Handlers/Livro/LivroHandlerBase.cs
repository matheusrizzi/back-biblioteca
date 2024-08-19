using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Domain.Repositories;

namespace Basis.BibliotecaVirtual.Application.Handlers.Livro;

public abstract class LivroHandlerBase
{
    private IAssuntoRepository _assuntoRepository;
    private IAutorRepository _autorRepository;
    private IFormaCompraRepository _formaCompraRepository;

    public LivroHandlerBase(IAssuntoRepository assuntoRepository,
                            IAutorRepository autorRepository,
                            IFormaCompraRepository formaCompraRepository)
    {
        this._autorRepository = autorRepository;
        this._assuntoRepository = assuntoRepository;
        this._formaCompraRepository = formaCompraRepository;
    }

    protected async Task<IEnumerable<Domain.Entities.Assunto>> GetAssuntosLivro(IEnumerable<int> assuntosId)
    {
        var assuntos = new List<Domain.Entities.Assunto>();

        foreach (var id in assuntosId)
        {
            var assunto = await _assuntoRepository.GetByIdAsync(id);

            if (assunto != null)
                assuntos.Add(assunto);

        }

        return assuntos;
    }

    protected async Task<IEnumerable<Domain.Entities.Autor>> GetAutoresLivro(IEnumerable<int> autoresId)
    {
        var lista = new List<Domain.Entities.Autor>();

        foreach (var id in autoresId)
        {
            var autor = await _autorRepository.GetByIdAsync(id);

            if (autor != null)
                lista.Add(autor);
        }

        return lista;
    }

    protected async Task<IEnumerable<Domain.Entities.FormaCompra>> GetFormasCompraLivro(IEnumerable<PrecoLivro> precos)
    {
        var lista = new List<Domain.Entities.FormaCompra>();

        foreach (var preco in precos)
        {
            var formaCompra = await _formaCompraRepository.GetByIdAsync(preco.CodFo);

            if (formaCompra != null)
            {
                lista.Add(formaCompra);
            }
        }

        return lista;
    }
}
