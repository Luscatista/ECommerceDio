using ECommerceDio.Context;
using ECommerceDio.DTOs;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDio.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceDioContext _context;
    private readonly IClientRepository _clientRepository;
    private readonly IProductRepository _productRepository;

    public OrderRepository(ECommerceDioContext context, IClientRepository clientRepository, IProductRepository productRepository)
    {
        _context = context;
        _clientRepository = clientRepository;
        _productRepository = productRepository;
    }
    public List<Order>? GetAll()
    {
        var orders = _context.Orders.ToList();
        if (orders == null)
            throw new NullReferenceException();

        return orders;
    }
    public Order? GetById(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
            throw new NullReferenceException();

        return order;
    }
    // public void Create(OrderDTO orderDTO)
    // {
    //     // Cliente Nome
    //     // Produtos e quantidades

    //     var client = _clientRepository.GetByEmail(orderDTO.ClientEmail);
    //     if (client == null)
    //         throw new Exception();

    //     var order = new Order
    //     {
    //         ClientId = client.Id,
    //         TotalPrice = 0
    //     };

    //     var orderItemList = new Dictionary<int, int>();
    //     var shoppingCart = new List<OrderItem>();

    //     foreach (KeyValuePair<string, int> item in orderDTO.ProductAndQuantities)
    //     {
    //         var product = _productRepository.GetByName(item.Key);
    //         if (product == null)
    //             throw new Exception($"{item.Key} is invalid.");

    //         order.TotalPrice += product.Price * item.Value;

    //         orderItemList.Add(product.Id, item.Value);            
    //     } 

    //     foreach(var item in orderItemList)
    //     {
    //         var orderItem = _context.OrderItems.FirstOrDefault(o => o.ProductId == item.Key && o.OrderId == order.Id);
    //         if(orderItem == null)
    //         {
    //             var newOrderItem = new OrderItem
    //             {
    //                 ProductId = item.Key
    //             }
    //             _context.OrderItems.Add();
    //         }
    //     }
        
    
    //     // _context.Orders.Add(order);
    //     // _context.SaveChanges();

    // }
    public Order? Update(int id, Order order)
    {
        throw new NotImplementedException();
    }
    public Order? Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            throw new NullReferenceException();

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return order;
    }
}