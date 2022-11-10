using GMicroservices.User.Application.Services.Abstraction;
using GMicroservices.User.Domain.Entities.Dto;
using GMicroservices.User.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GMicroservices.User.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userType}", Name = "GetUsers")]
        [ProducesResponseType(typeof(ServiceResponse<GetUsersResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers(int userType)
        {
            var response = await _userService.GetUsers(userType);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse<GenericAddingDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDiscount([FromBody] UserRegDto user)
        {
            await _userService.AddUser(user);
            return NoContent();
        }
    }
}
