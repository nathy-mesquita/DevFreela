using MediatR;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllUserSkills
{
    public class GetAllUserSkillsQuery : IRequest<List<UserSkillViewModel>>
    {
        public GetAllUserSkillsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}