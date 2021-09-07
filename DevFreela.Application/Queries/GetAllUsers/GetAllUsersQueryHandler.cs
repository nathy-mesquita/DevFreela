using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevFreela.Core.Repositories;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository) 
            => _userRepository = userRepository;

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var userViewModel = users
            .Select(u => new UserViewModel(u.Id, u.FullName, u.CreatedAt))
            .ToList();
            return userViewModel;
        }
    }
}