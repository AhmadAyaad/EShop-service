using EShop.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace EShop.Presistance.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.HasMany(category => category.Products)
                   .WithOne(product => product.Category)
                   .HasForeignKey(product => product.CategoryId);
            builder.HasData(new List<Category> {
                new Category {Id =1, Name= "TVs",CreatedAt = DateTime.Now},
                new Category {Id =2, Name= "Laptop" ,CreatedAt = DateTime.Now},
                new Category {Id =3, Name= "Sound Systems",CreatedAt = DateTime.Now},
            });
        }
    }
}
