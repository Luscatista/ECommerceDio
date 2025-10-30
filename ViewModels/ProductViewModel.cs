namespace ECommerceDio.ViewModels;

public record ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; } = default!;
    public int AvaiableStock { get; set; } = default!;
}