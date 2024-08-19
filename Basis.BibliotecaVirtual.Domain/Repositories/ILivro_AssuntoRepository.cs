using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Domain.Repositories;

public interface ILivro_AssuntoRepository
{
    Task<IEnumerable<Livro_Assunto>> GetByIdAsync(int id);
    Task DeleteAsync(Livro_Assunto entity);
}
