using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using FluentValidation;

namespace Basis.BibliotecaVirtual.Application.Validators;

public class CreateAssuntoCommandValidator : AbstractValidator<CreateAssuntoCommand>
{
    public CreateAssuntoCommandValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("A descrição do assunto é obrigatória.")
            .Length(1, 20).WithMessage("A descrição deve ter entre 1 e 20 caracteres.");
    }
}
