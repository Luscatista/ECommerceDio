using ECommerceDio.DTOs;
using ECommerceDio.Models;
using ECommerceDio.ViewModels;

namespace ECommerceDio.interfaces;

public interface IClientRepository
{
    List<ClientViewModel>? GetAll();
    ClientViewModel? GetById(int id);
    ClientViewModel? GetByEmail(string clientEmail);
    void Create(ClientDTO clientDTO);
    ClientViewModel? Update(int id, ClientDTO clientDTO);
    ClientViewModel? Delete(int id);
}