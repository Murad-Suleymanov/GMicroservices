using MongoDB.Driver;
using GMicroservices.Product.Data;
using ent = GMicroservices.Product.Domain.Entities;

namespace GMicroservices.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(ent.Product product)
        {
            await _context
               .Products.InsertOneAsync(product);
        }

        public  async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<ent.Product> filter = Builders<ent.Product>.Filter.Eq(p => p.Id, id);

            var deleteResult =  await _context
               .Products
               .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<ent.Product> GetProductByIdAsync(string id)
        {
            return await _context
              .Products
              .Find(p => p.Id == id)
              .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ent.Product>> GetProductsAsync()
        {
            return await _context
                .Products
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<ent.Product>> GetProductsByCategoryAsync(string category)
        {
            return await _context
               .Products
               .Find(p => p.Category == category)
               .ToListAsync();
        }

        public async Task<IEnumerable<ent.Product>> GetProductsByNameAsync(string name)
        {
            FilterDefinition<ent.Product> filter = Builders<ent.Product>.Filter.Eq(p => p.Name, name);

            return await _context
               .Products
               .Find(filter)
               .ToListAsync();
        }

        public async Task<bool> UpdateProduct(ent.Product product)
        {
            var updateResult = await _context
                .Products
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
