namespace Infrastructure.Common.Persistence.Entities;

public class CustomerEntity : BaseEntity
{
    public string Email { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public List<OrderEntity> Orders { get; set; }
}
