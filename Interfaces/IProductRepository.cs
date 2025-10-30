using ECommerceDio.Models;
using ECommerceDio.ViewModels;

namespace ECommerceDio.interfaces;

public interface IProductRepository
{
    List<Product>? GetAll();
    // Product? GetById(int id);
    Product? GetByName(string productName);
    Product Create(Product product);
    // Product? Update(int id, Product product);
    // Product? Delete(int id);
}