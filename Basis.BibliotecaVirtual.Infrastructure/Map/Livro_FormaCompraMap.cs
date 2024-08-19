using Basis.BibliotecaVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.BibliotecaVirtual.Infrastructure.Map;

public class Livro_FormaCompraMap : IEntityTypeConfiguration<Livro_FormaCompra>
{
    public void Configure(EntityTypeBuilder<Livro_FormaCompra> builder)
    {

        builder.HasKey(la => new { la.LivroCodL, la.FormaCompraCodFo });

        builder.HasOne(la => la.Livro)
            .WithMany(l => l.LivrosFormaCompras)
            .HasForeignKey(la => la.LivroCodL)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(la => la.FormaCompra)
            .WithMany(a => a.LivroFormaCompras)
            .HasForeignKey(la => la.FormaCompraCodFo)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
