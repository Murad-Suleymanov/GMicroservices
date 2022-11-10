using GMicroservices.User.Application.Services.Abstraction;
using GMicroservices.User.Domain.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMicroservices.User.Test
{
    public class UserServiceFake : IUserService
    {
        private readonly List<UserRegDto> _users;
        public UserServiceFake()
        {
            _users = new List<UserRegDto>
            {
                new UserRegDto
                {
                    Email = "123@gmail.com",
                    FirstName = "amurd",
                    Surname = "asdda",
                    Username = "uasanfe",
                    UserTypeId = Domain.Enums.UserTypes.User
                },
                new UserRegDto
                {
                    Email = "12ad3@gmail.com",
                    FirstName = "amdurd",
                    Surname = "asddsda",
                    Username = "uassdanfe",
                    UserTypeId = Domain.Enums.UserTypes.Curier
                },
                new UserRegDto
                {
                    Email = "12aasdd3@gmail.com",
                    FirstName = "amdasdurd",
                    Surname = "as1321ddsda",
                    Username = "uassasdfdanfe",
                    UserTypeId = Domain.Enums.UserTypes.Admin
                },
            };
        }
        public Task<ServiceResponse<GenericAddingDto>> AddUser(UserRegDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GenericExistingDto>> ExistUser(int userId, int userType)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetUsersResponseDto>> GetUsers(int userType)
        {
            return Task.Run<ServiceResponse<GetUsersResponseDto>>(() =>
            {
                var users = _users.Where(d => (int)d.UserTypeId == userType)
                .Select(d => new UserDto
                {
                    Email = d.Email,
                    FirstName = d.FirstName,
                    Username = d.Username,
                    Surname = d.Surname,
                    UserTypeId = d.UserTypeId
                }).ToList();

                return new ServiceResponse<GetUsersResponseDto>
                {
                    Data = new GetUsersResponseDto
                    {
                        Users = users
                    }
                };
            });
        }
    }
}
