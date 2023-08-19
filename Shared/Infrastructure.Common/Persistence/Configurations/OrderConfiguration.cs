using Infrastructure.Common.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.Property(t => t.Status)
            .IsRequired();
        builder.Property(t => t.Price)
            .IsRequired();
        builder.Property(t => t.OrderItems)
            .HasMaxLength(500)
            .IsRequired();
    }
}