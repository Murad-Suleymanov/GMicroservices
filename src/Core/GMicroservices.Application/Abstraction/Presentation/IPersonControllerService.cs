
namespace NetTestTask.Application.Abstraction.Presentation
{
    public interface IPersonControllerService
    {
        Task<ServiceResponse<long>> Create(string json);
        Task<ServiceResponse<string>> GetAllRequests(GetAllRequestDto model);
    }
}
