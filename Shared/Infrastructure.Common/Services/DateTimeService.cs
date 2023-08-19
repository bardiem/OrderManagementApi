using Infrastructure.Common.Services.Interfaces;

namespace Infrastructure.Common.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}