using System.Collections.Generic;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        int IProjectService.Create(NewProjectInputModel inputModel)
        {
            throw new System.NotImplementedException();
        }

        void IProjectService.CreateComment(CreateCommentInputModel inputModel)
        {
            throw new System.NotImplementedException();
        }

        void IProjectService.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        void IProjectService.Finish(int id)
        {
            throw new System.NotImplementedException();
        }

        List<ProjectViewModel> IProjectService.GetAll(string query)
        {
            throw new System.NotImplementedException();
        }

        ProjectDetailsViewModel IProjectService.GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        void IProjectService.Start(int id)
        {
            throw new System.NotImplementedException();
        }

        void IProjectService.Update(UpdateProjectInputModel inputModel)
        {
            throw new System.NotImplementedException();
        }
    }
}