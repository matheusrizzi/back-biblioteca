using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Domain.Entities;

namespace Basis.BibliotecaVirtual.Application.Builder;

public class CreateLivroBuilder
{
    private Livro _livro;
    private IEnumerable<Assunto> _assuntos;
    private IEnumerable<Autor> _autores;
    private IEnumerable<FormaCompra> _precos;
    private CreateLivroCommand _command;

    public CreateLivroBuilder(CreateLivroCommand command)
    {
        _livro = Livro.Create(command.Livro.Titulo, command.Livro.Editora, command.Livro.Edicao, command.Livro.AnoPublicacao);
        _command = command;
    }

    public CreateLivroBuilder AddAssuntos(IEnumerable<Assunto> assuntos)
    {
        foreach (var assunto in assuntos)
        {
            _livro.LivrosAssuntos.Add(new Livro_Assunto
            {
                Assunto = assunto,
                Livro = _livro
            });
        }

        return this;
    }

    public CreateLivroBuilder AddAutores(IEnumerable<Autor> autores)
    {
        foreach (var autor in autores)
        {
            _livro.LivrosAutores.Add(new Livro_Autor
            {
                Autor = autor,
                Livro = _livro
            });
        }

        return this;
    }

    public CreateLivroBuilder AddFormasCompra(IEnumerable<FormaCompra> formasCompra)
    {
        foreach (var forma in formasCompra)
        {
            var preco = _command.Livro.Precos.FirstOrDefault(x => x.CodFo == forma.CodFo);

            if (preco == null)
                throw new Exception("Preço não pode ser nulo.");

            _livro.LivrosFormaCompras.Add(new Livro_FormaCompra
            {
                FormaCompra = forma,
                Livro = _livro,
                Preco = preco.Preco
            });
        }

        return this;
    }

    public Livro Build() => _livro;
}
