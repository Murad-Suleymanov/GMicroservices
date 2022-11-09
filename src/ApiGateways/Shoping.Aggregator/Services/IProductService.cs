using Shoping.Aggregator.Models;

namespace Shoping.Aggregator.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProduct();
        Task<IEnumerable<ProductModel>> GetProductByCategory(string category);
        Task<ProductModel> GetProduct(string id);
    }
}
