using ECommerceDio.Models.Enums;

namespace ECommerceDio.Models;

public class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.PendingPayment;
    public decimal TotalPrice { get; set; }
    public int ClientId { get; set; } = default!;
    public Client? Client { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}