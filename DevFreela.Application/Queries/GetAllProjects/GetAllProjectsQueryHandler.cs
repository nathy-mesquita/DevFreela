using MediatR;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async System.Threading.Tasks.Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            var projectViewModel = await projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)) 
            .ToListAsync();

            return projectViewModel;
        }
    }
}