using MongoDB.Driver;
using E = GMicroservices.Product.Domain.Entities;

namespace GMicroservices.Product.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<E.Product> Products { get; }
    }
}
