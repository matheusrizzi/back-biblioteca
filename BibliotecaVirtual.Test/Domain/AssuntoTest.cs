using Basis.BibliotecaVirtual.CrossCutting.Exceptions;
using Basis.BibliotecaVirtual.Domain.Entities;
using Bogus;
using FluentAssertions;

namespace BibliotecaVirtual.Test.Domain;

public class AssuntoTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("My Description has more than 20 characters")]
    public void When_Create_Assunto_With_Invalid_Description_Should_Throw_Exception(string description)
    {
        var exception = Assert.Throws<DomainException>(() => Assunto.Create(description));

        exception.Should().NotBeNull();
        exception.Message.Should().NotBeEmpty();
        exception.Message.Should().Be("Descrição não pode ser vazia nem ter mais de 20 caracteres.");
    }

    [Fact]
    public void When_Create_Assunto_With_Valid_Description_Should_Return_New_Assunto()
    {
        var faker = new Faker("pt_BR");
        var description = faker.Random.Word();

        var newSubject = Assunto.Create(description);

        newSubject.Should().NotBeNull();

        newSubject.Descricao.Should()
                            .NotBeNullOrEmpty()
                            .And
                            .BeSameAs(description);
    }
}