using Xunit;
using DevFreela.Core.Enums;
using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        [Trait("CreateProject", "Start")]
        public void CreatedProjet_Started_ReturnStatusInProgressNotNull()
        {
            //Given
            var project = new Project("Titulo do Projeto", "Descrição do projeto", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);


            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            //When
            project.Start();

            //Then
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}