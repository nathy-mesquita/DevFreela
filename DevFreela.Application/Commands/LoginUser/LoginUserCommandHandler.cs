using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Todo: Utilizar altoritmo para criar Hash de senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            //Todo: Buscar no banco um User que tenha o meu email e senha no formato Hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            //Todo: Se não existir, erro no login
            if(user == null)
            {
                return null;
            }
            //Todo: Se existir, gero o token passando os dados do usuário
            var token = _authService.GenereteJwtToken(user.Email, user.Role);
            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;
        }
    }
}