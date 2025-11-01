using ECommerceDio.Context;
using ECommerceDio.DTOs;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using ECommerceDio.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDio.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceDioContext _context;

    public ProductRepository(ECommerceDioContext context)
    {
        _context = context;
    }

    public List<ProductViewModel>? GetAll()
    {
        var productList = _context.Products.Select(p => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            AvaiableStock = p.AvaiableStock
        }).ToList();

        if (productList == null)
            throw new Exception();

        return productList;
    }
    
    // public Product? GetById(int id)
    // {
    //     var product = _context.Products.FirstOrDefault(p => p.Id == id);
    //     if (product == null)
    //         throw new NullReferenceException();

    //     return product;
    // }
    public void Create(ProductDTO productDTO)
    {
        var product = new Product
        {
            Name = productDTO.Name,
            Description = productDTO.Description,
            Price = productDTO.Price,
            AvaiableStock = productDTO.AvaiableStock
        };

        _context.Products.Add(product);
        _context.SaveChanges();

    }
    // public Product? Update(int id, Product productUpdated)
    // {
    //     var product = _context.Products.Find(id);
    //     if (product == null)
    //         throw new NullReferenceException();

    //     product.Name = productUpdated.Name;
    //     product.Description = productUpdated.Description;
    //     product.Price = productUpdated.Price;
    //     product.AvaiableStock = productUpdated.AvaiableStock;

    //     _context.SaveChanges();

    //     return productUpdated;
    // }
    // public Product? Delete(int id)
    // {
    //     var product = _context.Products.Find(id);
    //     if (product == null)
    //         throw new NullReferenceException();

    //     _context.Remove(product);
    //     _context.SaveChanges();

    //     return product;
    // }

    public ProductViewModel? GetByName(string productName)
    {
        var product = _context.Products
        .Where(p => p.Name.ToLower()
        .Contains(productName.ToLower()))
        .FirstOrDefault();

        if (product == null)
            throw new NullReferenceException();

        var productViewModel = new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            AvaiableStock = product.AvaiableStock
        };
        return productViewModel;
    }
}