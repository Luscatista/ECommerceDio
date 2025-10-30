using ECommerceDio.Models;

namespace ECommerceDio.interfaces;

public interface IOrderRepository
{
    List<Order>? GetAll();
    Order? GetById(int id);
    // void Create(Order order);
    Order? Update(int id, Order order);
    Order? Delete(int id);
}