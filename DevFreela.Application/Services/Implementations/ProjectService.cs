using System.Linq;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration) 
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        } 
            

        public List<ProjectViewModel> GetAll(string query)
        {
            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "SELECT Id, Title, CreatedAt FROM Project";
                return sqlConnection.Query<ProjectViewModel>(script).ToList();
            }

            //! Caso esteja usando o EF Core In Memory o Dapper não funcionará
            //Busca todos os projetos
            var projects = _dbContext.Projects;

            var projectViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)) // Seleciona o projeto que foi buscado dizendo que ele é do tipo ProjectVieeModel e passa as propriedades criadas no construtor
            .ToList(); //Gera uma lista a partir das projeções desses dados

            return projectViewModel;
        }
        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer) 
                .SingleOrDefault(p => p.Id == id);
            if (project == null) return null;

            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "SELECT  p.Id, p.Title, p.Description, p.TotalCost, p.StartedAt, p.FinishedAt,  u.FullName,  FROM Projects p INNER JOIN Users u ON p.Id = u.Id;";
                return sqlConnection.Query<ProjectDetailsViewModel>(script).SingleOrDefault(p => p.Id == id);
            }

            //! Caso esteja usando o EF Core In Memory o Dapper não funcionará
            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
            );
            return projectDetailsViewModel;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            //! Converter um NewprojectInputModel para um Project - AutoMapper
            //Faremos isso a princípio de maneira manual
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project.Id;
        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script ="UPDATE Projects SET Title = @title, Description = @description, TotalCost = @totalcost WHERE Id = @id";
                sqlConnection.Execute(script, new {title = project.Title, description = project.Description, totalcost = project.TotalCost, id = project.Id});
            }
            //! Utilizando EF Core
           // _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "UPDATE Projects SET Status = @status WHERE Id = @id";
                sqlConnection.Execute(script, new {status = project.Status, id = project.Id});
            }
            //! Utilizando EF Core
            //_dbContext.SaveChanges();
        }
        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComments(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }
        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";
                sqlConnection.Execute(script, new {status = project.Status, startedat = project.StartedAt, id});
            }
            //! Utilizando EF Core
           // _dbContext.SaveChanges();
        }
        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
            // Todo: Refatorando com Dapper
            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "UPDATE Projects SET Status = @status, FinishedAt = @finishedAt WHERE Id = @id";
                sqlConnection.Execute(script, new {status = project.Status, finishedat = project.FinishedAt, id});
            }
            //! Utilizando EF Core
            //_dbContext.SaveChanges();
        }
    }
}