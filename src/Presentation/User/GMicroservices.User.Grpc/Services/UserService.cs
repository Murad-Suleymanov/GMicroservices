using AutoMapper;
using GMicroservices.User.Application.Services.Abstraction;
using GMicroservices.User.Grpc;
using Grpc.Core;

namespace GMicroservices.User.Grpc.Services
{
    public class UserService : UserProtoService.UserProtoServiceBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger, IMapper mapper, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        public override async Task<GetExistUserResponse> CheckExist(GetExistUserRequest request, ServerCallContext context)
        {
            var isExist = await _userService.ExistUser(request.UserId, request.UserType);

            return Task.FromResult(new GetExistUserResponse
            {
                IsExist = isExist
            });
        }
    }
}