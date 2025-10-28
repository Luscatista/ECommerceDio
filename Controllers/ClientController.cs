using ECommerceDio.DTOs;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;
    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_clientRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var client = _clientRepository.GetById(id);
            return Ok(client);
        }
        catch
        {
        return NotFound("Client not found.");
        }
    }

    [HttpPost]
    public IActionResult Create(ClientDTO clientDTO)
    {
        _clientRepository.Create(clientDTO);

        return Created();
    }
}