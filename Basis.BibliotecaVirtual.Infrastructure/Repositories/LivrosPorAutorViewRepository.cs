using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public class LivrosPorAutorViewRepository : BaseRepository, ILivrosPorAutorViewRepository
{
    private readonly BibliotecaDbContext _context;

    public LivrosPorAutorViewRepository(BibliotecaDbContext context):base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LivrosPorAutorView>> GetAllAsync()
    {
        return await _context.LivrosPorAutor.ToListAsync();
    }
}
