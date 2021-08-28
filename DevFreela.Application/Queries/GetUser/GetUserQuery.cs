using MediatR;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetUserById
{
    public class GetUserQuery : IRequest<UserDetailsViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}