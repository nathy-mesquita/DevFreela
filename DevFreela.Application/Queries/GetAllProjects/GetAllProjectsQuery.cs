using MediatR;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}