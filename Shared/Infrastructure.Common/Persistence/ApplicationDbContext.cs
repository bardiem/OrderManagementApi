using Infrastructure.Common.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Common.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<OrderEntity>()
            .HasOne(p => p.Customer)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.CustomerId)
            .HasConstraintName("ForeignKey_Customer_Order");

        base.OnModelCreating(builder);
    }
}