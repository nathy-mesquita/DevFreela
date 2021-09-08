using FluentValidation;
using DevFreela.Application.Commands.CreateComment;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250)
                .WithMessage("O conteúdo é obrigatório!");

            RuleFor(c => c.IdProject)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id do projeto é obrigatório!");

            RuleFor(c => c.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id do usuário é obrigatório");
        }
    }
}