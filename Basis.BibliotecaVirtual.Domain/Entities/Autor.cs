using Basis.BibliotecaVirtual.CrossCutting.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Basis.BibliotecaVirtual.Domain.Entities;

public class Autor
{
    public Autor()
    {
    }
    public Autor(string nome)
    {
        Nome = nome;
    }

    [Key]
    public int CodAu { get; set; }

    [MaxLength(40)]
    public string Nome { get; set; }

    public ICollection<Livro_Autor> LivrosAutores { get; set; }

    public void SetNome(string nome)
    {
        if (string.IsNullOrEmpty(nome) || nome.Length > 40)
            throw new DomainException("Nome não pode ser vazio nem ter mais de 40 caracteres.");

        Nome = nome;
    }

    public static Autor Create(string nome)
    {
        return new Autor(nome);
    }
}
