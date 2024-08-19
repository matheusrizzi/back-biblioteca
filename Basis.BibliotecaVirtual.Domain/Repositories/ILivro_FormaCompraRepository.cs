using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories;

public interface ILivro_FormaCompraRepository
{
    Task<IEnumerable<Livro_FormaCompra>> GetByIdAsync(int id);
    Task DeleteAsync(Livro_FormaCompra entity);
}
