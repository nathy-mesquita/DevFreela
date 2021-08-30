using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.CreateComment
{

    //Todo: Refatorar as classes commands para Handler
    public class CreateCommentCommandHandle : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateCommentCommandHandle(DevFreelaDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComments(request.Content, request.IdProject, request.IdUser);
            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}