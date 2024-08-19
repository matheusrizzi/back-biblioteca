using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Application.Handlers.Livro;
using Basis.BibliotecaVirtual.Domain.Entities;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Bogus;
using FluentAssertions;
using Moq;

namespace BibliotecaVirtual.Test.Application.Handlers
{
    public class UpdateLivroCommandHandlerTest
    {
        private readonly Mock<ILivroRepository> _mockLivroRepository;
        private readonly Mock<IAssuntoRepository> _mockAssuntoRepository;
        private readonly Mock<IAutorRepository> _mockAutorRepository;
        private readonly Mock<IFormaCompraRepository> _mockFormaCompraRepository;

        public UpdateLivroCommandHandlerTest()
        {
            this._mockLivroRepository = new Mock<ILivroRepository>();
            this._mockAssuntoRepository = new Mock<IAssuntoRepository>();
            this._mockAutorRepository = new Mock<IAutorRepository>();
            this._mockFormaCompraRepository = new Mock<IFormaCompraRepository>();
        }

        [Fact]
        public async void When_update_an_invalid_book_Should_throws_exception()
        {
            IEnumerable<Livro> livros = null;

            _mockLivroRepository.Setup(x => x.GetAllAsync())
                                .ReturnsAsync(livros);

            var command = new UpdateLivroCommand()
            {
                CodL = 9
            };

            var handler = new UpdateLivroCommandHandler(_mockLivroRepository.Object, _mockAssuntoRepository.Object, _mockAutorRepository.Object, _mockFormaCompraRepository.Object);
            var exception = await Assert.ThrowsAsync<Exception>(() =>  handler.Handle(command, new CancellationToken()));

            Assert.Equal("Livro não encontrado.", exception.Message);
        }

        [Fact]
        public async void When_update_a_valid_book_Should_Return_True()
        {
            var livro = CreateRandomLivro();

            _mockLivroRepository.Setup(x => x.GetByIdAsync(livro.Codl))
                                .ReturnsAsync(livro);

            _mockLivroRepository.Setup(x => x.UpdateAsync(It.IsAny<Livro>()))
                    .Returns(Task.FromResult(true));

            _mockAssuntoRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                                  .ReturnsAsync(new Assunto() {  CodAs = 1, Descricao = "mock"});

            _mockAutorRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                      .ReturnsAsync(new Autor() { CodAu = 1, Nome = "mock" });

            var assuntos = new List<int>() { 1, 2, 3 };
            var autores = new List<int>() { 1, 2, 3 };
            var precos = new List<PrecoLivro>() { new PrecoLivro() { CodFo = 1, Preco = 10 } };

            var command = new UpdateLivroCommand()
            {
                CodL = livro.Codl,
                AnoPublicacao = livro.AnoPublicacao,
                Edicao = livro.Edicao,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Assuntos = assuntos,
                Autores = autores,
                Precos = precos
            };

            var handler = new UpdateLivroCommandHandler(_mockLivroRepository.Object, _mockAssuntoRepository.Object, _mockAutorRepository.Object, _mockFormaCompraRepository.Object);
            var result = await handler.Handle(command, new CancellationToken());

            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
        }

        private Livro CreateRandomLivro()
        {
            var faker = new Faker("pt_BR");
            return new Livro()
            {
                Codl = faker.Random.Number(1, 100),
                Titulo = faker.Random.Word(),
                Edicao = faker.Random.Number(max: 999),
                Editora = faker.Random.Word(),
                AnoPublicacao = faker.Random.Number(1900, DateTime.Now.Year),
                LivrosAutores = new List<Livro_Autor>(),
                LivrosAssuntos = new List<Livro_Assunto>(),
                LivrosFormaCompras = new List<Livro_FormaCompra>()
            };
        }
    }
}
