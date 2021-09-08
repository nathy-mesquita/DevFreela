using FluentValidation;
using DevFreela.Application.Commands.FinishProject;

namespace DevFreela.Application.Validators
{
    public class FinishProjectCommandValidator : AbstractValidator<FinishProjectCommand>
    {
        public FinishProjectCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id é obrigatório!");
        }
    }
}