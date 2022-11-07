using E = GMicroservices.Product.Domain.Entities;

namespace GMicroservices.Product.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<E.Product>> GetProductsAsync();
        Task<E.Product> GetProductByIdAsync(string id);
        Task<IEnumerable<E.Product>> GetProductsByNameAsync(string name);
        Task<IEnumerable<E.Product>> GetProductsByCategoryAsync(string category);

        Task CreateProduct(E.Product product);
        Task<bool> UpdateProduct(E.Product product);
        Task<bool> DeleteProduct(string id);
    }
}
