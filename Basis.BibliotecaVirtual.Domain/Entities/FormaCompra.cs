using System.ComponentModel.DataAnnotations;

namespace Basis.BibliotecaVirtual.Domain.Entities;

public class FormaCompra
{
    [Key]
    public int CodFo { get; set; }

    [MaxLength(20)]
    public string Descricao { get; set; }
    public ICollection<Livro_FormaCompra> LivroFormaCompras { get; set; }

}

