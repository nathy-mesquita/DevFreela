using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectQueryHandler(IProjectRepository projectRepository) 
            => _projectRepository = projectRepository;

        public async Task<ProjectDetailsViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
            );
            return projectDetailsViewModel;
        }
    }
}