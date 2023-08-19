using Infrastructure.Common.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.Property(t => t.UserName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(t => t.PasswordHash)
            .HasMaxLength(200)
            .IsRequired();
    }
}