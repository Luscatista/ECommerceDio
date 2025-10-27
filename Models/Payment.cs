namespace ECommerceDio.Models;

public class Payment
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public string MethodPayment { get; set; } = null!;
    public DateTime PaymentDate { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; } = null!;
}