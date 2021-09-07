using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public SkillRepository(DevFreelaDbContext dbContext, string connectionString)
        {
            _dbContext = dbContext;
            _connectionString = connectionString;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.ToListAsync();

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