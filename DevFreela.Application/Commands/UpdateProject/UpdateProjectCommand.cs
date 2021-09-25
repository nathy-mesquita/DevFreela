using MediatR;
using Newtonsoft.Json;

namespace DevFreela.Application.Commands.UpdateProject
{
    /// <summary>
    /// Update project command input
    /// </summary>
    public class UpdateProjectCommand : IRequest<Unit>
    {
        internal int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}