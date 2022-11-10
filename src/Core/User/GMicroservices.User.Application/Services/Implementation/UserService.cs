using AutoMapper;
using GMicroservices.User.Application.Services.Abstraction;
using GMicroservices.User.Domain.Entities.Dao;
using GMicroservices.User.Domain.Entities.Dto;
using GMicroservices.User.Repositories;
using Npgsql.TypeMapping;
using System.Reflection.Metadata.Ecma335;

namespace GMicroservices.User.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        readonly IMapper _mapper;
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GenericAddingDto>> AddUser(UserRegDto model)
        {
            var userDao = _mapper.Map<UserDao>(model);
            bool isAdded = await _userRepository.Add(userDao);

            return new ServiceResponse<GenericAddingDto>
            {
                Data = new GenericAddingDto
                {
                    IsSuccess = isAdded
                }
            };
        }

        public async Task<ServiceResponse<GenericExistingDto>> ExistUser(int userId, int userType)
        {
            var isExist = await _userRepository.CheckExist(userId,userType);

            return new ServiceResponse<GenericExistingDto>
            {
                Data = new GenericExistingDto
                {
                    IsExist = isExist
                }
            };
        }

        public async Task<ServiceResponse<GetUsersResponseDto>> GetUsers(int userType)
        {
            var userDaos = await _userRepository.GetUsers(userType);
            var userDtos = _mapper.Map<List<UserDto>>(userDaos);

            return new ServiceResponse<GetUsersResponseDto>
            {
                Data = new GetUsersResponseDto
                {
                    Users = userDtos
                }
            };
        }
    }
}
