using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateCommentCommandHandler(IProjectRepository projectRepository) 
            => _projectRepository = projectRepository;

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComments(request.Content, request.IdProject, request.IdUser);
            await _projectRepository.AddCommentAsync(comment);
            return Unit.Value;
        }
    }
}