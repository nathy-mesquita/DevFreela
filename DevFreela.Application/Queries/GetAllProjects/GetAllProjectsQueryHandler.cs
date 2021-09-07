using MediatR;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Core.Repositories;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository) 
            => _projectRepository = projectRepository;

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            var projectViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)) 
            .ToList();
            return projectViewModel;
        }
    }
}