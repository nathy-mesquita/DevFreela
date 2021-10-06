using Moq;
using Xunit;
using System;
using DevFreela.API;
using System.Threading;
using DevFreela.Core.Entities;
using DevFreela.Core.Services;
using DevFreela.Core.Repositories;
using DevFreela.Application.Commands.CreateUser;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        [Trait("CreateUser", "Handle")]
        public async void InputUser_Created_ReturnId()
        {
            //Arrage
            var userRepositoryMock = new Mock<IUserRepository>();
            var authserviceMock = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand
            {
                FullName = "Maria Mesquita",
                Email = "e@email.com",
                Password = "Abcd@1234",
                Role = Roles.Client,
                BirthDate = new DateTime(2000, 12, 21),
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authserviceMock.Object);

            //Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);
            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once);
            authserviceMock.Verify(ur => ur.ComputeSha256Hash(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [Trait("CreateUser", "Role")]
        [InlineData("DevFreela_Admin")]
        [InlineData("DevFreela_Client")]
        [InlineData("DevFreela_Freelancer")]
        public void InputRole_CreateUser_ReturnValidRole(string value)
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FullName = "Maria Mesquita",
                Email = "e@email.com",
                Password = "Abcd@1234",
                Role = value,
                BirthDate = new DateTime(2000, 12, 21),
            };

            var admin = Roles.Administrador;
            var client = Roles.Client;
            var freelancer = Roles.Freelancer;

            //Act
            var result = $"{admin} " + $"{client} " + $"{freelancer} ";

            //Assert
            Assert.Contains(createUserCommand.Role, result);
        }
    }
}
