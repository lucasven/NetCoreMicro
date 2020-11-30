using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NetCoreMicro.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void home_controller_get_should_return_string_content()
        {
            //arrange
            var controller = new HomeController();

            //act
            var result = controller.Get();
            var contentResult = result as ContentResult;

            //assert
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Hello from NetCoreMicro API!");
        }
    }
}
