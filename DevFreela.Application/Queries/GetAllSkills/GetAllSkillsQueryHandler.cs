using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;
            var skillViewModel = await skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToListAsync();
            return skillViewModel;

            //Usando Dapper $ dotnet add package Dapper --version 2.0.90
            // using (var sqlConnection = new SqlConnection(_connectionString))
            // {
            //     sqlConnection.Open();
            //     var script = "SELECT Id, Description FROM Skills";
            //     var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);
            //     return skills.ToList();
            // }
        }

    }
}