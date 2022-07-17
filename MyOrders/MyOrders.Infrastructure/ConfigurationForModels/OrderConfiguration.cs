using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrders.Domain;

namespace MyOrders.Infrastructure.ConfigurationForModels
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders");

            builder
                .HasKey(x => x.Id);

            builder.Property<DateTime>("RecivedDate")
                        .HasColumnType("date");
        }
    }
}
