using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetUserById
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository) 
            => _userRepository = userRepository;

        public async Task<UserDetailsViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }
            
            var userDetailsViewModel = new UserDetailsViewModel(
                user.Id,
                user.FullName,
                user.Email,
                user.BirthDate,
                user.CreatedAt,
                user.Active
            );
            return userDetailsViewModel;
        }
    }
}