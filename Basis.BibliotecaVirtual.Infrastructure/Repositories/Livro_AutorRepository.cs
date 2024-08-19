using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Infrastructure.Repositories
{
    public class Livro_AutorRepository : BaseRepository, ILivro_AutorRepository
    {
        private BibliotecaDbContext _context;

        public Livro_AutorRepository(BibliotecaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Livro_Autor entity)
        {
            this._context.Livro_Autor.Remove(entity);
        }

        public async Task<IEnumerable<Livro_Autor>> GetByIdAsync(int id)
        {
            return this._context.Livro_Autor.Where(x=> x.LivroCodL == id);
        }
    }
}
