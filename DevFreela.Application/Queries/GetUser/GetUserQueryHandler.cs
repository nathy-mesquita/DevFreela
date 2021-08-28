using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetUserById
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetUserQueryHandler(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<UserDetailsViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

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