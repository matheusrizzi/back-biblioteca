using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories;

public interface IAssuntoRepository
{
    Task<IEnumerable<Assunto>> GetAllAsync();
    Task<Assunto?> GetByIdAsync(int id);
    Task<Assunto> AddAsync(Assunto entity);
    Task UpdateAsync(Assunto entity);
    Task DeleteAsync(Assunto entity);
}