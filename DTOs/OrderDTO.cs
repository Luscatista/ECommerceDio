namespace ECommerceDio.DTOs;

public record OrderDTO
{
    public string ClientEmail { get; set; } = null!;
    public Dictionary<string, int> ProductAndQuantities { get; set; } = null!;
         
}