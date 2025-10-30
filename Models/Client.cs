using ECommerceDio.Models.Enums;

namespace ECommerceDio.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Role Role { get; set; } = Role.Editor;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}