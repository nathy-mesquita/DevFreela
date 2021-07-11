using System.Linq;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext) 
        => _dbContext = dbContext;

        public List<ProjectViewModel> GetAll(string query)
        {
            //Busca todos os projetos
            var projects = _dbContext.Projects;

            var projectViewModel = projects
            .Select(p => new ProjectViewModel(p.Title, p.CreatedAt)) // Seleciona o projeto que foi buscado dizendo que ele é do tipo ProjectVieeModel e passa as propriedades criadas no construtor
            .ToList(); //Gera uma lista a partir das projeções desses dados

            return projectViewModel;
        }
        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
            );
            return projectDetailsViewModel;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            //! Converter um NewprojectInputModel para um Project - AutoMapper
            //Faremos isso a princípio de maneira manual
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);
            return project.Id;
        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
        }
        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComments(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);
        }
        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
        }
        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
        }
    }
}