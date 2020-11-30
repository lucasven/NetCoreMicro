using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetCoreMicro.API.Controllers;
using NetCoreMicro.API.Repositories;
using NetCoreMicro.Common.Commands;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Unit.Controllers
{
    public class ActivitiesControllerTests
    {
        [Fact]
        public async Task activities_controller_post_should_return_accepted()
        {
            //arrange
            var busClientMock = new Mock<IBusClient>();
            var activityRepositoryMock = new Mock<IActivityRepository>();
            var controller = new ActivitiesController(busClientMock.Object, activityRepositoryMock.Object);

            var userId = new Guid();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity
                    (new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userId.ToString())
                    }, "test")
                    )
                }
            };

            var command = new CreateActivity()
            {
                ID = Guid.NewGuid(),
                UserId = userId
            };

            //act
            var result = await controller.Post(command);
            var contentResult = result as AcceptedResult;

            //assert
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"activities/{command.ID}");
        }
    }
}
