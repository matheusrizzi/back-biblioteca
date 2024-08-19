using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class AutorRepository : BaseRepository, IAutorRepository
{
    private readonly BibliotecaDbContext _context;

    public AutorRepository(BibliotecaDbContext context) : base(context) => _context = context;

    public async Task<Autor> AddAsync(Autor entity)
    {
        await _context.Autor.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Autor entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Autor cannot be null.");

        _context.Autor.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Autor>> GetAllAsync() => await _context.Autor.ToListAsync();
    public async Task<Autor?> GetByIdAsync(int id) => await _context.Autor.FindAsync(id);

    public async Task UpdateAsync(Autor entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Autor cannot be null.");

        _context.Autor.Update(entity);
        await _context.SaveChangesAsync();
    }
}
