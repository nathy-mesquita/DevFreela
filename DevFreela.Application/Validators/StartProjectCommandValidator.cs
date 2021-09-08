using FluentValidation;
using DevFreela.Application.Commands.StartProject;

namespace DevFreela.Application.Validators
{
    public class StartProjectCommandValidator : AbstractValidator<StartProjectCommand>
    {
        public StartProjectCommandValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id é obrigatório!");
        }
    }
}