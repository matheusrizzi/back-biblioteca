using Basis.BibliotecaVirtual.CrossCutting.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Basis.BibliotecaVirtual.Domain.Entities;

public class Assunto
{
    [Key]
    public int CodAs { get; set; }

    [MaxLength(20)]
    public string Descricao { get; set; }
    public ICollection<Livro_Assunto> LivrosAssuntos { get; set; }

    public Assunto() { }

    public Assunto(string descricao)
    {
        SetDescricao(descricao);
    }

    public void SetDescricao(string descricao)
    {
        if (string.IsNullOrEmpty(descricao) || descricao.Length > 20)
            throw new DomainException("Descrição não pode ser vazia nem ter mais de 20 caracteres.");

        Descricao = descricao;
    }

    public static Assunto Create(string descricao)
    {
        return new Assunto(descricao);
    }

}