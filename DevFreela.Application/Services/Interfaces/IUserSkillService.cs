using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserSkillService
    {
        List<UserSkillViewModel> GetAll();
        
    }
}