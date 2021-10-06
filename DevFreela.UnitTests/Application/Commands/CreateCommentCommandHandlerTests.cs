using Moq;
using Xunit;
using System.Threading;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Application.Commands.CreateComment;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        [Trait("CreateComment", "Handle")]
        public async void InputComment_Executed_ReturNotNull()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var createCommentCommand = new CreateCommentCommand
            {
                Content = "Aqui tem um comentário de projeto",
                IdProject = 3,
                IdUser = 1
            };
            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock.Object);

            //Act
            var result = await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());


            //Assert
            Assert.True(true);
            projectRepositoryMock.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComments>()), Times.Once);

        }
    }
}
