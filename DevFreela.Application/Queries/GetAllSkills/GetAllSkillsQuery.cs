using MediatR;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
        public GetAllSkillsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}