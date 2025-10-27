using ECommerceDio.interfaces;
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
}