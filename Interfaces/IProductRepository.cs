using ECommerceDio.DTOs;
using ECommerceDio.Models;
using ECommerceDio.ViewModels;

namespace ECommerceDio.interfaces;

public interface IProductRepository
{
    List<ProductViewModel>? GetAll();
    // Product? GetById(int id);
    ProductViewModel? GetByName(string productName);
    void Create(ProductDTO productDTO);
    // Product? Update(int id, Product product);
    // Product? Delete(int id);
}