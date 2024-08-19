using Basis.BibliotecaVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.BibliotecaVirtual.Infrastructure.Map;

public class Livro_AutorMap : IEntityTypeConfiguration<Livro_Autor>
{
    public void Configure(EntityTypeBuilder<Livro_Autor> builder)
    {
        builder.HasKey(la => new { la.LivroCodL, la.AutorCodAu });

        builder.HasOne(la => la.Livro)
            .WithMany(l => l.LivrosAutores)
            .HasForeignKey(la => la.LivroCodL)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(la => la.Autor)
            .WithMany(a => a.LivrosAutores)
            .HasForeignKey(la => la.AutorCodAu)
            .OnDelete(DeleteBehavior.Restrict);
    }
}