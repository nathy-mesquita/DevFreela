using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevFreela.Core.Repositories;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllUserSkills
{
    public class GetAllUserSkillsQueryHandler : IRequestHandler<GetAllUserSkillsQuery, List<UserSkillViewModel>>
    {
        private readonly IUserSkillRepository _userSkillRepository;

        public GetAllUserSkillsQueryHandler(IUserSkillRepository userSkillRepository)
            => _userSkillRepository = userSkillRepository;

        public async Task<List<UserSkillViewModel>> Handle(GetAllUserSkillsQuery request, CancellationToken cancellationToken)
        {
            var userSkills = await _userSkillRepository.GetAllAsync();

            var userSkillViewModel = userSkills
                .Select(u => new UserSkillViewModel(u.IdUser, u.IdSkill))
                .ToList();
            return userSkillViewModel;
        }
    }
}