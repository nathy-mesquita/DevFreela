using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using System.Collections.Generic;
using DevFreela.Core.Repositories;
using DevFreela.Application.Queries.GetAllProjects;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        [Trait("GetProject", "Handle")]
        public async Task ThreeProjectsExist_Fetched_ReturnThreeProjectViewModels()
        {
            //Arrange
            var projects = new List<Project>
            {
                new Project("Titulo 1", "Descricao 1", 1, 2, 10000),
                new Project("Titulo 2", "Descricao 2", 1, 2, 20000),
                new Project("Titulo 3", "Descricao 3", 1, 2, 30000)
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var projectRepositoryMock = new Mock<IProjectRepository>();
            //Todo: Configurando o Metodo GetAllAsync para retornar o resultado que eu espero.
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}