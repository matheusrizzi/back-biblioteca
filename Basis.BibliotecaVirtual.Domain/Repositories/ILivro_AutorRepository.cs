using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories
{
    public interface ILivro_AutorRepository
    {
        Task<IEnumerable<Livro_Autor>> GetByIdAsync(int id);
        Task DeleteAsync(Livro_Autor entity);
    }
}
