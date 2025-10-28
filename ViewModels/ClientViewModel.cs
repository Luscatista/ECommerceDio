using ECommerceDio.Models;
using ECommerceDio.Models.Enums;

namespace ECommerceDio.ViewModels;

public class ClientViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }
}