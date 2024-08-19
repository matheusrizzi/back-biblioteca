using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);
    Task<Livro> AddAsync(Livro entity);
    Task UpdateAsync(Livro entity);
    Task DeleteAsync(Livro entity);
}
