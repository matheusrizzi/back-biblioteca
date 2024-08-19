using System.ComponentModel.DataAnnotations;

namespace Basis.BibliotecaVirtual.Domain.Entities;

public class Livro
{
    [Key] 
    public int Codl { get; set; }

    [MaxLength(40)] 
    public string Titulo { get; set; }

    [MaxLength(40)] 
    public string Editora { get; set; }

    public int Edicao { get; set; } 

    public int AnoPublicacao { get; set; }

    public ICollection<Livro_Autor> LivrosAutores { get; set; }

    public ICollection<Livro_Assunto> LivrosAssuntos { get; set; }
    public ICollection<Livro_FormaCompra> LivrosFormaCompras { get; set; }

    public static Livro Create(string titulo, string editora, int edicao, int ano)
    {
       return new Livro()
        {
            Titulo = titulo,
            Editora = editora,
            Edicao = edicao,
            AnoPublicacao = ano,
            LivrosAssuntos = new List<Livro_Assunto>(),
            LivrosAutores = new List<Livro_Autor>(),
            LivrosFormaCompras = new List<Livro_FormaCompra>()
        };
    }

    public void SetAutores(ICollection<Livro_Autor> autores) => this.LivrosAutores = autores;
    
    public void AddAssunto(Assunto assunto)
    {
        if(this.LivrosAssuntos == null)
            this.LivrosAssuntos = new List<Livro_Assunto>();

        this.LivrosAssuntos.Add(new Livro_Assunto()
        {
           
        });
    } 
}
