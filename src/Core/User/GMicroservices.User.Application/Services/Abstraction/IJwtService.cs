namespace GMicroservices.User.Application.Services.Abstraction
{
    public interface IJwtService
    {
        Task<string> GetJwt(string jwt);
    }
}
