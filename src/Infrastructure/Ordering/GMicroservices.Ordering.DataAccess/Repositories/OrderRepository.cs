using GMicroservices.Ordering.Application.Contracts.Persistence;
using GMicroservices.Ordering.Domain.Entities;
using GMicroservices.Ordering.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GMicroservices.Ordering.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                    .Where(o => o.UserName == userName)
                                    .ToListAsync();
            return orderList;
        }
    }
}