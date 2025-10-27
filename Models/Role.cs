namespace ECommerceDio.Models;

public class Role
{
    public int Id { get; set; }
    public string RoleDescription { get; set; } = null!;
    public ICollection<Client> Clients { get; set; } = new List<Client>();
}