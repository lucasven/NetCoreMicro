using NetCoreMicro.Common.Auth;
using NetCoreMicro.Services.Identity.Domain.Repositories;
using NetCoreMicro.Services.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using NetCoreMicro.Services.Identity.Domain.Models;
using NetCoreMicro.Services.Identity.Services;
using FluentAssertions;

namespace NetCoreMicro.Services.Activities.Tests.Unit.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task user_service_login_should_return_jwt()
        {
            var email = "test@test.com";
            var password = "secret";
            var name = "test";
            var salt = "salt";
            var hash = "hash";
            var token = "token";
            JsonWebToken webToken = new JsonWebToken()
            {
                Token = token
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            var jwtHandlerMock = new Mock<IJwtHandler>();

            encrypterMock.Setup(c => c.GetSalt()).Returns(salt);
            encrypterMock.Setup(x => x.GetHash(password, salt)).Returns(hash);
            jwtHandlerMock.Setup(x => x.Create(It.IsAny<Guid>())).Returns(new JsonWebToken
            {
                Token = token
            });

            var user = new User(email, name);
            user.SetPassword(password, encrypterMock.Object);
            userRepositoryMock.Setup(x => x.GetAsync(email)).ReturnsAsync(user);

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object , jwtHandlerMock.Object);

            var jwt = await userService.LoginAsync(email, password);
            userRepositoryMock.Verify(x => x.GetAsync(email), Times.Once);
            jwtHandlerMock.Verify(x => x.Create(It.IsAny<Guid>()), Times.Once);
            jwt.Should().NotBeNull();
            
            jwt.Should().BeEquivalentTo(webToken);
        }
    }
}
