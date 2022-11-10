using GMicroservices.User.Application.Services.Abstraction;
using GMicroservices.User.Domain.Entities.Dto;
using GMicroservices.User.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GMicroservices.User.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet("{userType}", Name = "GetUsers")]
        [ProducesResponseType(typeof(ServiceResponse<GetUsersResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers(int userType)
        {
            if(userType > 3)
            {
                return BadRequest();
            }
            var response = await _userService.GetUsers(userType);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse<GenericAddingDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateUser([FromBody] UserRegDto user)
        {
            await _userService.AddUser(user);
            return NoContent();
        }

        [HttpGet("{userId}/token")]
        public async Task<IActionResult> GetToken(int userId)
        {
            await _jwtService.GetJwt("empty");
            return NoContent();
        }

    }
}
