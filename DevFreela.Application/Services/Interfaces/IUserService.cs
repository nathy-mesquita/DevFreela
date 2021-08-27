using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll(string query);
        UserDetailsViewModel GetById(int id);
        //int Create(CreateUserInputModel inputModel);
    }
}