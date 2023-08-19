namespace Application.DTOs;

public class OrderDTO
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public byte Status { get; set; }

    public IList<string> OrderItems { get; set; }
}
