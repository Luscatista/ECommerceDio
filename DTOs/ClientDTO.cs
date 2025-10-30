using ECommerceDio.Models;
using ECommerceDio.Models.Enums;

namespace ECommerceDio.DTOs;

public record ClientDTO
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Role Role { get; set; } = Role.Editor;
}