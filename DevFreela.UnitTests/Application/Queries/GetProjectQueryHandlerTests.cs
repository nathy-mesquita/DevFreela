using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Queries.GetProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectQueryHandlerTests
    {
        [Fact]
        [Trait("GetProjectQuery", "Handle")]
        public async Task OneProjectExist_Fetched_ReturnProjectDetailsViewModel()
        {
            //Arrange
            var projectDetails = new List<ProjectDetailsViewModel>
            {
                new ProjectDetailsViewModel(1,"Titulo 1", "Descricao 1", 1000, new DateTime(2021,11,01), new DateTime(2021,11,01), "Nome do cliente completo 1", "Nome do Freelance completo 1"),
                new ProjectDetailsViewModel(2,"Titulo 2", "Descricao 2", 2000, new DateTime(2021,11,01), new DateTime(2021,11,01), "Nome do cliente completo 2", "Nome do Freelance completo 2")
            };
            var project = new Project("Titulo 1", "Descricao 1", 1, 2, 10000);
            var projects = new List<Project>
            {
                new Project("Titulo 1", "Descricao 1", 1, 2, 10000),
                new Project("Titulo 2", "Descricao 2", 1, 2, 20000),
                new Project("Titulo 3", "Descricao 3", 1, 2, 30000)
            };
            //Todo: Mocando a Interface que o Handler tem como dependencia
            var projectRepositoryMock = new Mock<IProjectRepository>();
            //Todo: Configurando o Metodo GetDetailsByIdAsync para retornar o resultado que eu espero.
            projectRepositoryMock.Setup(pr => pr.GetDetailsByIdAsync(It.IsAny<int>())); //.Returns(It.IsAny<Project>())

            var getProjectQuery = new GetProjectQuery(1);
            var getProjectQueryHandler = new GetProjectQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectDetailViewModel = await getProjectQueryHandler.Handle(getProjectQuery, CancellationToken.None);

            //Assert
            //Assert.NotNull(projectDetailViewModel);
            //Assert.NotEmpty(projectDetailViewModel);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
