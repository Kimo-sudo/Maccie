using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Prijs)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}