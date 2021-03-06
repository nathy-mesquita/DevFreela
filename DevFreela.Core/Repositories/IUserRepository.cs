using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task  AddAsync(User user);
    }
}