using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllUsersQueryHandler(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _dbContext.Users;

            var userViewModel = await users
            .Select(u => new UserViewModel(u.Id, u.FullName, u.CreatedAt))
            .ToListAsync();

            return userViewModel;
        }
    }
}