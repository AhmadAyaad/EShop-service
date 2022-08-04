using EShop.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Presistance.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(user => user.Invoices)
                   .WithOne(invoice => invoice.User)
                   .HasForeignKey(invoice => invoice.UserId);
        }
    }
}
