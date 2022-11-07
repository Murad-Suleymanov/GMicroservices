using GMicroservices.Parcel.Domain.Entities;

namespace GMicroservices.Parcel.Repositories
{
    public interface IParcelRepository
    {
        Task<ShoppingCart> GetParcel(string userName);
        Task<ShoppingCart> UpdateParcel(ShoppingCart basket);
        Task DeleteParcel(string userName);
    }
}
