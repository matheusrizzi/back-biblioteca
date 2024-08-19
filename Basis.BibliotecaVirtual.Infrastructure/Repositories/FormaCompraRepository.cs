using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class FormaCompraRepository : BaseRepository, IFormaCompraRepository
{
    private readonly BibliotecaDbContext _context;
    public FormaCompraRepository(BibliotecaDbContext context) : base(context) => _context = context;

    public async Task<FormaCompra> AddAsync(FormaCompra entity)
    {
        await _context.FormaCompra.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(FormaCompra entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "FormaCompra cannot be null.");

        _context.FormaCompra.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FormaCompra>> GetAllAsync() => await _context.FormaCompra.ToListAsync();

    public async Task<FormaCompra?> GetByIdAsync(int id) => await _context.FormaCompra.FindAsync(id);

    public async Task UpdateAsync(FormaCompra entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "FormaCompra cannot be null.");

        _context.FormaCompra.Update(entity);
        await _context.SaveChangesAsync();
    }
}
