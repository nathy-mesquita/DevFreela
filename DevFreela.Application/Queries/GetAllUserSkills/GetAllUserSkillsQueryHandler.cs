using MediatR;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllUserSkills
{
    public class GetAllUserSkillsQueryHandler : IRequestHandler<GetAllUserSkillsQuery, List<UserSkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllUserSkillsQueryHandler(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<List<UserSkillViewModel>> Handle(GetAllUserSkillsQuery request, CancellationToken cancellationToken)
        {
            var userSkills = _dbContext.UserSkills;
            var userSkillViewModel = await userSkills
                .Select(u => new UserSkillViewModel(u.IdUser, u.IdSkill))
                .ToListAsync();
            return userSkillViewModel;
        }
    }
}