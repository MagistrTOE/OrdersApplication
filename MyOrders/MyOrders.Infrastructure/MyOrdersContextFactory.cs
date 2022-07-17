using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyOrders.Infrastructure
{
    class MyOrdersContextFactory : IDesignTimeDbContextFactory<MyOrdersContext>
    {
        public MyOrdersContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyOrdersContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=localhost;Port=5432;Database=MyOrdersDb;");
            return new MyOrdersContext(optionsBuilder.Options);
        }
    }
}