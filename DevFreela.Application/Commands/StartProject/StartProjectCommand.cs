using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    /// <summary>
    /// Start project command
    /// </summary>
    public class StartProjectCommand : IRequest<Unit>
    {
        public StartProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}