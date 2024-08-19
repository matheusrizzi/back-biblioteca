using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Infrastructure.Map;
using Microsoft.EntityFrameworkCore;

namespace Basis.BibliotecaVirtual.Infrastructure.Persistence;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }

    public DbSet<Assunto> Assunto { get; set; }
    public DbSet<Autor> Autor { get; set; }
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Livro_Autor> Livro_Autor { get; set; }
    public DbSet<Livro_Assunto> Livro_Assunto { get; set; }
    public DbSet<Livro_FormaCompra> Livro_FormaCompra { get; set; }
    public DbSet<FormaCompra> FormaCompra { get; set; }
    public DbSet<LivrosPorAutorView> LivrosPorAutor { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<LivrosPorAutorView>()
            .ToView("LivrosPorAutorView")
            .HasNoKey();

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new Livro_AutorMap());
        modelBuilder.ApplyConfiguration(new Livro_AssuntoMap());
        modelBuilder.ApplyConfiguration(new Livro_FormaCompraMap());
        modelBuilder.ApplyConfiguration(new FormaCompraMap());


    }
}