using Moq;
using NetCoreMicro.Services.Activities.Domain.Models;
using NetCoreMicro.Services.Activities.Domain.Repositories;
using NetCoreMicro.Services.Activities.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Unit.Services
{
    public class ActivityServiceTests
    {
        [Fact]
        public async Task acitvity_service_add_async_should_succeed()
        {
            var category = "test";
            var activityRepositoryMock = new Mock<IActivityRepository>();   
            var categoryRepositoryMock = new Mock<ICategoryRepository>();

            categoryRepositoryMock.Setup(x => x.GetAsync(category))
                .ReturnsAsync(new Category(category));

            var activityService = new ActivityService(activityRepositoryMock.Object, categoryRepositoryMock.Object);

            var id = Guid.NewGuid();
            await activityService.AddAsync(id, Guid.NewGuid(), category, "activity", "description", DateTime.UtcNow);

            categoryRepositoryMock.Verify(x => x.GetAsync(category), Times.Once);
            activityRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Activity>()), Times.Once);
        }
    }
}
