using MediatR;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}