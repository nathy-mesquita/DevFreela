using DevFreela.Application.Queries.GetAllUserSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllUserSkillsQueryHandlerTests
    {
        [Fact]
        [Trait("GetUserSkill", "Handle")]
        public async Task FourUserSkillExist_Fetched_ReturnFourUserSkillViewModels()
        {
            //Arrange
            var userSkill = new List<UserSkill>
            {
                new UserSkill(1,2),
                new UserSkill(1,3),
                new UserSkill(1,4),
                new UserSkill(1,5)
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var userSkillRepositoryMock = new Mock<IUserSkillRepository>();
            //Todo: Configurando o Metodo GetAllAsync para retornar o resultado que eu espero.
            userSkillRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(userSkill);

            var getAllUserSkillsQuery = new GetAllUserSkillsQuery("");
            var getAllUserSkillsQueryHandler = new GetAllUserSkillsQueryHandler(userSkillRepositoryMock.Object);

            //Act
            var userSkillViewModelList = await getAllUserSkillsQueryHandler.Handle(getAllUserSkillsQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(userSkillViewModelList);
            Assert.NotEmpty(userSkillViewModelList);
            Assert.Equal(userSkill.Count, userSkillViewModelList.Count);

            userSkillRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
