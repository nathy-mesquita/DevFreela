using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    /// <summary>
    /// Delete project command
    /// </summary>
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}