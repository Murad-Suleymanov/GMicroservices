using Shoping.Aggregator.Models;

namespace Shoping.Aggregator.Services
{
    public interface IParcelService
    {
        Task<ParcelModel> GetParcel(string userName);
    }
}
