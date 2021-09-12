using FluentValidation;
using System.Text.RegularExpressions;
using DevFreela.Application.Commands.CreateUser;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido!");
            
            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter no mínimo 8 dígitos, uma letra maiúscula, uma minúscula e um caractere especial!");

            RuleFor(u => u.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome é obrigatório!");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}