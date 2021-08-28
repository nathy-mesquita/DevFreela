using MediatR;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}