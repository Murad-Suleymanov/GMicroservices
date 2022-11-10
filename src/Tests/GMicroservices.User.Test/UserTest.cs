using GMicroservices.User.Application.Services.Abstraction;
using GMicroservices.User.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GMicroservices.User.Test
{
    public class UserTest
    {
        private readonly UserController _controller;
        private readonly IUserService _service;
        public UserTest()
        {
            _service = new UserServiceFake();
            _controller = new UserController(_service, null);
        }

        [Fact]
        public void GetUsersTest_ReturnOk()
        {
            var okResult = _controller.GetUsers(3).Result;

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetUsersTest_ReturnBadRequest()
        {
            var okResult = _controller.GetUsers(4).Result;

            Assert.IsType<BadRequestObjectResult>(okResult as BadRequestObjectResult);
        }
    }
}