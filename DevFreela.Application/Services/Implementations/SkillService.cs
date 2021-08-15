using System.Linq;
using System.Collections.Generic;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration) 
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<SkillViewModel> GetAll()
        {
            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString)) //Instanciando a SqlConnection passado nossa connnectionString
            {
                sqlConnection.Open(); // Abre a connecção com o banco
                var script = "SELECT Id, Description FROM Skills"; //Monta o script de consulta no banco
                return sqlConnection.Query<SkillViewModel>(script).ToList(); //Realiza a consulta, passando o script e o tipo esperado de retorno
            }
            //! Caso esteja usando o EF Core In Memory o Dapper não funcionará
            var skills = _dbContext.Skills;
            var skillViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();
            return skillViewModel;
        }
    }
}