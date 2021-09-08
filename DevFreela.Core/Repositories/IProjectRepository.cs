using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetDetailsByIdAsync(int id);
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task SaveChangesAsync();
        Task AddCommentAsync(ProjectComments projectComments);
    }
}