using GMicroservices.User.Domain.Entities.Dto;

namespace GMicroservices.User.Application.Services.Abstraction
{
    public interface IUserService
    {
        Task<ServiceResponse<GenericAddingDto>> AddUser(UserRegDto model);
        Task<ServiceResponse<GenericExistingDto>> ExistUser(int userId, int userType);
        Task<ServiceResponse<GetUsersResponseDto>> GetUsers(int userType);
    }
}
