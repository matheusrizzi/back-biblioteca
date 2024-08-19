using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task<Autor> AddAsync(Autor entity);
    Task UpdateAsync(Autor entity);
    Task DeleteAsync(Autor entity);
}
