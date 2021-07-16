using System.Linq;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext) 
        => _dbContext = dbContext;

        public List<UserViewModel> GetAll(string query)
        {
            var users = _dbContext.Users;

            var userViewModel = users
            .Select(u => new UserViewModel(u.Id, u.FullName, u.CreatedAt))
            .ToList();

            return userViewModel;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
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

        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(user);
            return user.Id;
        }
    }
}