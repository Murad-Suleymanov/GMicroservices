using GMicroservices.Ordering.Application.Models;

namespace GMicroservices.Ordering.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
