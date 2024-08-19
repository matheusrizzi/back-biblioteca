using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class Livro_FormaCompraRepository : BaseRepository, ILivro_FormaCompraRepository
{
    private BibliotecaDbContext _context;

    public Livro_FormaCompraRepository(BibliotecaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task DeleteAsync(Livro_FormaCompra entity)
    {
        this._context.Livro_FormaCompra.Remove(entity);
    }

    public async Task<IEnumerable<Livro_FormaCompra>> GetByIdAsync(int id)
    {
        return this._context.Livro_FormaCompra.Where(x => x.LivroCodL == id);
    }
}
