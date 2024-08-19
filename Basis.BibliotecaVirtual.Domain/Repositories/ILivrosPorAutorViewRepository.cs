using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories;

public interface ILivrosPorAutorViewRepository
{
    Task<IEnumerable<LivrosPorAutorView>> GetAllAsync();

}
