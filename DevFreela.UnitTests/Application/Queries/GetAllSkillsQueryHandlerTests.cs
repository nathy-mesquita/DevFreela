using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        [Trait("GetAllSkills", "Handle")]
        public async Task ThreeSkillsExist_Fetched_ReturnThreeSkillsViewModels()
        {
            //Arrange
            var skills = new List<Skill>
            {
                new Skill("Comunicativo"),
                new Skill("Introvertido"),
                new Skill("Dedicado")
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var skillRepositoryMock = new Mock<ISkillRepository>();
            //Todo: Configurando o Metodo GetAllAsync para retornar o resultado que eu espero.
            skillRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(skills);

            var getAllSkillsQuery = new GetAllSkillsQuery("");
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            //Act
            var skillViewModelList = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(skillViewModelList);
            Assert.NotEmpty(skillViewModelList);
            Assert.Equal(skills.Count, skillViewModelList.Count);

            skillRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
