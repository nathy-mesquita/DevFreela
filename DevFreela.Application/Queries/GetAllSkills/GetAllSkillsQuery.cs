using MediatR;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
        
    }
}