using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class Livro_AssuntoRepository : BaseRepository, ILivro_AssuntoRepository
{
    private BibliotecaDbContext _context;

    public Livro_AssuntoRepository(BibliotecaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task DeleteAsync(Livro_Assunto entity)
    {
        this._context.Livro_Assunto.Remove(entity);
    }

    public async Task<IEnumerable<Livro_Assunto>> GetByIdAsync(int id)
    {
        return this._context.Livro_Assunto.Where(x => x.LivroCodL == id);
    }
}
