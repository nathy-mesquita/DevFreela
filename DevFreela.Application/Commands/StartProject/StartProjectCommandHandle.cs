using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandle : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public StartProjectCommandHandle(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Start();
            await _dbContext.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}