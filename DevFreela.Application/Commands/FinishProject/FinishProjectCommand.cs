using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    /// <summary>
    /// Finish project command
    /// </summary>
    public class FinishProjectCommand : IRequest<Unit>
    {
        public FinishProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}