using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class AssuntoRepository : BaseRepository, IAssuntoRepository
{
    private readonly BibliotecaDbContext _context;

    public AssuntoRepository(BibliotecaDbContext context):base(context) => _context = context;

    public async Task<Assunto> AddAsync(Assunto assunto)
    {
        await _context.Assunto.AddAsync(assunto);
        await _context.SaveChangesAsync();
        return assunto;
    }

    public async Task DeleteAsync(Assunto assunto)
    {
        if (assunto == null)
            throw new ArgumentNullException(nameof(assunto), "Assunto cannot be null.");

        _context.Assunto.Remove(assunto);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Assunto>> GetAllAsync() => await _context.Assunto.ToListAsync();

    public async Task<Assunto?> GetByIdAsync(int codAs) => await _context.Assunto.FindAsync(codAs);

    public async Task UpdateAsync(Assunto assunto)
    {
        if (assunto == null)
            throw new ArgumentNullException(nameof(assunto), "Assunto cannot be null.");

        _context.Assunto.Update(assunto);
        await _context.SaveChangesAsync();
    }
}
