using Microsoft.EntityFrameworkCore;
using MyOrders.Domain;

namespace MyOrders.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        protected DbContext _dbContext;
        protected DbSet<Order> _dbSet;

        public OrderRepository(MyOrdersContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Order>();
        }

        public async Task<List<Order>> GetOrdersList()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Create(Order order)
        {
            await _dbSet.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
