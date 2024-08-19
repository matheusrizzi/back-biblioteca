using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class LivroRepository : BaseRepository, ILivroRepository
{
    private readonly BibliotecaDbContext _context;
    private const string LIVRO_CANNOT_NULL = "Livro cannot be null.";

    public LivroRepository(BibliotecaDbContext context) : base(context) => _context = context;

    public async Task<Livro> AddAsync(Livro entity)
    {
        await _context.Livro.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Livro entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), LIVRO_CANNOT_NULL);

        _context.Livro.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Livro>> GetAllAsync() => await _context.Livro.Include(l => l.LivrosAutores)
                                                                               .ThenInclude(la => la.Autor)
                                                                               .Include(l => l.LivrosAssuntos)
                                                                               .ThenInclude(ls => ls.Assunto)
                                                                               .Include(l => l.LivrosFormaCompras)
                                                                               .ThenInclude(lf=> lf.FormaCompra).ToListAsync();

    public async Task<Livro?> GetByIdAsync(int id) => await _context.Livro.Include(l => l.LivrosAutores)
                                                                               .ThenInclude(la => la.Autor)
                                                                               .Include(l => l.LivrosAssuntos)
                                                                               .ThenInclude(ls => ls.Assunto)
                                                                               .Include(l => l.LivrosFormaCompras)
                                                                               .ThenInclude(lf => lf.FormaCompra).FirstOrDefaultAsync(x=>x.Codl == id);

    public async Task UpdateAsync(Livro entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), LIVRO_CANNOT_NULL);

        _context.Livro.Update(entity);
        await _context.SaveChangesAsync();
    }
}
