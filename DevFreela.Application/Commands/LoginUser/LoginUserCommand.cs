using DevFreela.Application.Models.ViewModels;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    /// <summary>
    /// Request Login 
    /// </summary>
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}