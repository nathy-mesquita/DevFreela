using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Core.Repositories
{
    public interface IUserSkillRepository
    {
        Task<List<UserSkill>> GetAllAsync();
    }
}