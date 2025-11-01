using ECommerceDio.DTOs;
using ECommerceDio.Exceptions;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_orderRepository.GetAll());
        }
        catch
        {
            return NotFound("Empty list.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(_orderRepository.GetById(id));
        }
        catch
        {
        return NotFound("Order not found.");
        }
    }

    [HttpPost]
    public IActionResult Create(OrderDTO orderDTO)
    {
        try
        {
            _orderRepository.Create(orderDTO);
            return Created();
        }
        catch (InsufficientStockException)
        {
            return BadRequest("Insufficient Stock");
        }
    }

    // [HttpPut("{id}")]
    // public IActionResult Update(int id, Order order)
    // {
    //     try
    //     {
    //         return Ok(_orderRepository.Update(id, order));
    //     }
    //     catch
    //     {
    //         return NotFound("Order not found.");
    //     }
    // }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_orderRepository.Delete(id));
        }
        catch
        {
            return NotFound("Order not found.");
        }
    }
}