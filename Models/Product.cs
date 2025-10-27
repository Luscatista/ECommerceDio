namespace ECommerceDio.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; } = default!;
    public int AvaiableStock { get; set; } = default!;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}