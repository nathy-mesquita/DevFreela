using FluentValidation;
using DevFreela.Application.Commands.CreateProject;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("O título é obrigatório!");

            RuleFor(p => p.Description)
                .MaximumLength(250)
                .WithMessage("Tamanho máximo de descrição é de 250 caracteres!");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0)
                .ScalePrecision(2, 6)
                .WithMessage("Total Cost é um valor em decimal de até 6 dígitos!");
        }
    }
}