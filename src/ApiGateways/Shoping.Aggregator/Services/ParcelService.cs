using Shoping.Aggregator.Extensions;
using Shoping.Aggregator.Models;

namespace Shoping.Aggregator.Services
{
    public class ParcelService : IParcelService
    {
        private readonly HttpClient _client;

        public ParcelService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ParcelModel> GetParcel(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/Parcel/{userName}");
            return await response.ReadContentAs<ParcelModel>();
        }
    }
}
