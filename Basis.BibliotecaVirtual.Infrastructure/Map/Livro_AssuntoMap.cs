using Basis.BibliotecaVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.BibliotecaVirtual.Infrastructure.Map;

public class Livro_AssuntoMap : IEntityTypeConfiguration<Livro_Assunto>
{
    public void Configure(EntityTypeBuilder<Livro_Assunto> builder)
    {

        builder.HasKey(la => new { la.LivroCodL, la.AssuntoCodAs });

        builder.HasOne(la => la.Livro)
            .WithMany(l => l.LivrosAssuntos)
            .HasForeignKey(la => la.LivroCodL)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(la => la.Assunto)
            .WithMany(a => a.LivrosAssuntos)
            .HasForeignKey(la => la.AssuntoCodAs)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
