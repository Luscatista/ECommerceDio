using ECommerceDio.interfaces;
using ECommerceDio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var product = _productRepository.GetById(id);
            return Ok(product);
        }
        catch
        {
        return NotFound("Product not found.");
        }
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _productRepository.Create(product);

        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        try
        {            
            return Ok(_productRepository.Update(id, product));
        }
        catch
        {
            return NotFound("Product not found.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _productRepository.Delete(id);
            return NoContent();
        }
        catch
        {
            return NotFound("Product not found.");
        }
    }
}