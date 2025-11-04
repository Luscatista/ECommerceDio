using ECommerceDio.Context;
using ECommerceDio.DTOs;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using ECommerceDio.Services;
using ECommerceDio.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDio.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ECommerceDioContext _context;

    public ClientRepository(ECommerceDioContext context)
    {
        _context = context;
    }

    public List<ClientViewModel>? GetAll()
    {
        return _context.Clients.Select(c => new ClientViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Role = c.Role
        }).ToList();
    }
    public ClientViewModel? GetById(int id)
    {
        var client = _context.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
            throw new NullReferenceException();

        var clientViewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Role = client.Role,
        };

        return clientViewModel;
    }
    public Client? GetByEmailPassword(string email, string password)
    {
        var client = _context.Clients.FirstOrDefault(c => c.Email == email);
        if (client == null)
            throw new Exception();
        
        var passwordService = new PasswordService();
        var result = passwordService.VerifyPassword(client, password);

        if(result == true)
        {
            return client;
        }
        
        return null;
    }
    public ClientViewModel? GetByEmail(string clientEmail)
    {
        var client = _context.Clients.Where(c => c.Email.ToLower().Contains(clientEmail.ToLower())).FirstOrDefault();
        if (client == null)
            throw new NullReferenceException();

        var clientViewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Role = client.Role,
        };

        return clientViewModel;   
    }
    public void Create(ClientDTO clientDTO)
    {
        var client = new Client
        {
            Name = clientDTO.Name,
            Email = clientDTO.Email,
            Password = clientDTO.Password,
            Role = clientDTO.Role
        };

        var passwordService = new PasswordService();
        client.Password = passwordService.HashPassword(client);

        _context.Clients.Add(client);
        _context.SaveChanges();

        var clientViewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Role = client.Role,
        };
    }

    public ClientViewModel? Update(int id, ClientDTO clientDTO)
    {      
        var client = _context.Clients.Find(id);
        if (client == null)
            throw new NullReferenceException();

        client.Name = clientDTO.Name;
        client.Email = clientDTO.Email;
        client.Password = clientDTO.Password;
        client.Role = clientDTO.Role;

        var passwordService = new PasswordService();
        client.Password = passwordService.HashPassword(client);

        _context.SaveChanges();

        var clientViewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Role = client.Role,
        };

        return clientViewModel;              
    }

    public ClientViewModel? Delete(int id)
    {
        var client = _context.Clients.Find(id);
        if (client is null)
            throw new Exception();

        _context.Clients.Remove(client);
        _context.SaveChanges();

        var clientViewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Role = client.Role,
        };

        return clientViewModel;
    }
}