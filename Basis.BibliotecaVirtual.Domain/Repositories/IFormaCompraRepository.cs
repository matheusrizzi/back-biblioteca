using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories
{
    public interface IFormaCompraRepository
    {
        Task<IEnumerable<FormaCompra>> GetAllAsync();
        Task<FormaCompra?> GetByIdAsync(int id);
        Task<FormaCompra> AddAsync(FormaCompra entity);
        Task UpdateAsync(FormaCompra entity);
        Task DeleteAsync(FormaCompra entity);
    }
}
