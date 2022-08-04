using EShop.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Presistance.EntityConfiguration
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(product => product.Description)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.HasOne(product => product.Discount)
                   .WithOne(discount => discount.Product)
                   .HasForeignKey<Discount>(discount => discount.ProductId);
        }
    }
}
