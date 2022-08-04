using EShop.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Presistance.EntityConfiguration
{
    public class InvoiceEntityConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(invoice => invoice.Id);
            builder.Property(invoice => invoice.UserId)
                   .IsRequired();
            builder.HasOne(invoice => invoice.Order)
                   .WithOne(order => order.Invoice)
                   .HasForeignKey<Invoice>(invoice => invoice.OrderId);
        }
    }
}
