namespace ECommerceDio.Models;

public class Order
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public decimal? TotalPrice { get; set; }
    public int ClientId { get; set; } = default!;
    public Client? Client { get; set; }
    public DateTime CreationDate { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}