using EShop.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Presistance.EntityConfiguration
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasMany(order => order.OrderItems)
                   .WithOne(orderItem => orderItem.Order)
                   .HasForeignKey(orderItem => orderItem.OrderId);
            builder.HasOne(order => order.User)
                   .WithMany(user => user.Orders)
                   .HasForeignKey(order => order.UserId);
        }
    }
}
