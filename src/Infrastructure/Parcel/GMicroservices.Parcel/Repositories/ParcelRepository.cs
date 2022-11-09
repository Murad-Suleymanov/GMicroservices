using GMicroservices.Parcel.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace GMicroservices.Parcel.Repositories
{
    public class ParcelRepository: IParcelRepository
    {
        private readonly IDistributedCache _redisCache;

        public ParcelRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<ShoppingCart> GetParcel(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateParcel(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));

            return await GetParcel(basket.Username);
        }

        public async Task DeleteParcel(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
