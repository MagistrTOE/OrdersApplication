using Microsoft.EntityFrameworkCore;
using MyOrders.Infrastructure.ConfigurationForModels;

namespace MyOrders.Infrastructure
{
    public class MyOrdersContext : DbContext
    {
        public MyOrdersContext(DbContextOptions<MyOrdersContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
