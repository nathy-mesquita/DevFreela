using System.Linq;
using System.Collections.Generic;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class UserSkillService : IUserSkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserSkillService(DevFreelaDbContext dbContext) 
        => _dbContext = dbContext;

        public List<UserSkillViewModel> GetAll()
        {
            var userSkills = _dbContext.UserSkills;
            var userSkillViewModel = userSkills
                .Select(u => new UserSkillViewModel(u.IdUser, u.IdSkill))
                .ToList();
            return userSkillViewModel;
        }
    }
}