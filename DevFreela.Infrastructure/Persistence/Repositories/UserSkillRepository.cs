using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserSkillRepository(DevFreelaDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<List<UserSkill>> GetAllAsync()
        {
            return await _dbContext.UserSkills.ToListAsync();
        }
    }
}