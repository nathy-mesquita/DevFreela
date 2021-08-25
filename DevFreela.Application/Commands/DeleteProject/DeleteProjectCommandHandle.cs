using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandle : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeleteProjectCommandHandle(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async  Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project =  _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}