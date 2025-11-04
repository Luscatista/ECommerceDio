using ECommerceDio.DTOs;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using ECommerceDio.Services;
using ECommerceDio.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;
    private readonly TokenService _tokenService;
    public ClientController(IClientRepository clientRepository, TokenService tokenService)
    {
        _clientRepository = clientRepository;
        _tokenService = tokenService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAll()
    {
        return Ok(_clientRepository.GetAll());
    }

    [HttpGet("{id}")]
    [Authorize]
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

    [HttpGet("Email")]
    [Authorize]
    public IActionResult GetByEmail(string clientEmail)
    {
        try
        {
            var client = _clientRepository.GetByEmail(clientEmail);
            return Ok(client);
        }
        catch
        {
            return NotFound("Client not found.");
        }
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginDTO loginDTO)
    {
        try
        {
            var client = _clientRepository.GetByEmailPassword(loginDTO.Email, loginDTO.Password);
            if (client == null)
                return Unauthorized("Email or password are invalid.");

            var clientViewModel = new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Role = client.Role
            };

            var token = _tokenService.GenerateToken(clientViewModel);

            return Ok(new
            {
                token,
                clientViewModel
            });
        }
        catch
        {
            return BadRequest("Email or password are invalid.");
        }
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(ClientDTO clientDTO)
    {
        _clientRepository.Create(clientDTO);

        return Created();
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Update(int id, ClientDTO clientDTO)
    {
        try
        {
            return Ok(_clientRepository.Update(id, clientDTO));
        }
        catch
        {
            return NotFound("Client not found.");
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_clientRepository.Delete(id));
        }
        catch
        {
            return NotFound("Client not found.");
        }
    }
}