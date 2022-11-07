using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using E = GMicroservices.Product.Domain.Entities;

namespace GMicroservices.Product.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var section = configuration.GetValue<string>("DatabaseSettings");
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<E.Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<E.Product> Products { get; }
    }
}
