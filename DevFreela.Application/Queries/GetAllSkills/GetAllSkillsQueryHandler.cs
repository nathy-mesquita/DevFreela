using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevFreela.Core.Repositories;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository) 
            => _skillRepository = skillRepository;

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            var skillViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();
            return skillViewModel;
        }
    }
}