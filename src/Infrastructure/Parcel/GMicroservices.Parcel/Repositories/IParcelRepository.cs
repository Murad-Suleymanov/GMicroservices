using GMicroservices.Parcel.Domain.Entities;

namespace GMicroservices.Parcel.Repositories
{
    public interface IParcelRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
