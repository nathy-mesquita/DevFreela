using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllUsersQueryHandlerTests
    {
        [Fact]
        [Trait("GetAllUser", "Handle")]
        public async Task FourUsersExist_Fetched_ReturnFourUsersViewModels()
        {
            //Arrange
            var users = new List<User>
            {
                new User("Aline Duarte", "aduarte@gmail.com", new DateTime(1997,12,12), "Abcd@1234", ""),
                new User("Bruna Lima", "bruna@gmail.com", new DateTime(1989,01,16), "Abcd@1234", ""),
                new User("Carla Sousa", "carla@gmail.com", new DateTime(1999,05,07), "Abcd@1234", ""),
                new User("Darving Smitch", "darving@gmail.com", new DateTime(1986,11,30), "Abcd@1234", "")
            };

            //Todo: Mocando a Interface que o Handler tem como dependencia
            var userRepositoryMock = new Mock<IUserRepository>();
            //Todo: Configurando o Metodo GetAllAsync para retornar o resultado que eu espero.
            userRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(users);

            var getAllUsersQuery = new GetAllUsersQuery("");
            var getAllUsersQueryHandler = new GetAllUsersQueryHandler(userRepositoryMock.Object);

            //Act
            var userViewModelList = await getAllUsersQueryHandler.Handle(getAllUsersQuery, CancellationToken.None);

            //Assert
            Assert.NotNull(userViewModelList);
            Assert.NotEmpty(userViewModelList);
            Assert.Equal(users.Count, userViewModelList.Count);

            userRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
