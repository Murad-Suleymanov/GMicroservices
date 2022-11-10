using Shoping.Aggregator.Extensions;
using Shoping.Aggregator.Models;

namespace Shoping.Aggregator.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            var response = await _client.GetAsync("/api/v1/Catalog");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProduct(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Catalog/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(string category)
        {
            var response = await _client.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<ProductModel>>();
        }
    }
}
