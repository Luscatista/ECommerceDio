using ECommerceDio.Context;
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

    public List<Product>? GetAll()
    {
        return _context.Products.ToList();
    }
    
    // public Product? GetById(int id)
    // {
    //     var product = _context.Products.FirstOrDefault(p => p.Id == id);
    //     if (product == null)
    //         throw new NullReferenceException();

    //     return product;
    // }
    public Product Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return product;
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

    public Product? GetByName(string productName)
    {
        var product = _context.Products
        .Where(p => p.Name.ToLower()
        .Contains(productName.ToLower()))
        .FirstOrDefault();

        if (product == null) 
            throw new NullReferenceException();

        return product;
    }
}