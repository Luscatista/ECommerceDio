using ECommerceDio.Models;

namespace ECommerceDio.DTOs;

public class ProductDTO
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; } = default!;
    public int AvaiableStock { get; set; } = default!;
}