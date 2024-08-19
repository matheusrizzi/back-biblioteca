using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Basis.BibliotecaVirtual.Infrastructure
{
    public class BibliotecaDbContextFactory : IDesignTimeDbContextFactory<BibliotecaDbContext>
    {
        public BibliotecaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliotecaDbContext>();
            optionsBuilder.UseSqlServer("Server=PC-RIZZI;Database=basisdb;User Id=Basis;TrustServerCertificate=True;");

            return new BibliotecaDbContext(optionsBuilder.Options);
        }
    }
}
