using System.Linq;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration) 
            => _dbContext = dbContext;

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;
            var skillViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();
            return skillViewModel;
        }
    }
}