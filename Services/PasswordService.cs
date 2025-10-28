using ECommerceDio.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerceDio.Services;

public class PasswordService
{
    private readonly PasswordHasher<Client> _hasher = new();

    public string HashPassword(Client client)
    {
        return _hasher.HashPassword(client, client.Password);
    }

    public bool VerifyPassword(Client client, string password)
    {
        var result = _hasher.VerifyHashedPassword(client, client.Password, password);

        return result == PasswordVerificationResult.Success;
    }
}