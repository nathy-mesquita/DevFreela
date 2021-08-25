using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandle : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public FinishProjectCommandHandle(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;
        
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Finish();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}