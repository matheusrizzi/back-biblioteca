using Basis.BibliotecaVirtual.Infrastructure.Persistence;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories;

public abstract class BaseRepository
{
    private BibliotecaDbContext _context;

    protected BaseRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
