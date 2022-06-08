using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(7,2)");

            builder.Property(p => p.Stock)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
