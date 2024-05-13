using CatalogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogApp.Infrastructure.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

        builder.Property(p => p.Price).HasPrecision(10, 2);
        builder.Property(p => p.ImageUrl).HasMaxLength(250);
        builder.Property(p => p.Stock).HasDefaultValue(1).IsRequired();
        builder.Property(p => p.RegisterDate).IsRequired();


        builder.HasOne(e => e.Category).WithMany(e => e.Products)
            .HasForeignKey(e => e.CategoryId);
    }
}
