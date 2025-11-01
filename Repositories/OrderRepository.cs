using System.Security.Cryptography.X509Certificates;
using ECommerceDio.Context;
using ECommerceDio.DTOs;
using ECommerceDio.Exceptions;
using ECommerceDio.interfaces;
using ECommerceDio.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDio.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceDioContext _context;
    private readonly IClientRepository _clientRepository;
    public OrderRepository(ECommerceDioContext context, IClientRepository clientRepository)
    {
        _context = context;
        _clientRepository = clientRepository;
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
    public void Create(OrderDTO orderDTO)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {

            var client = _clientRepository.GetByEmail(orderDTO.ClientEmail);
            if (client == null)
                throw new Exception("Client not found.");

            var order = new Order
            {
                ClientId = client.Id,
                TotalPrice = 0
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            var orderItemList = new List<OrderItem>();

            foreach (KeyValuePair<string, int> item in orderDTO.ProductAndQuantities)
            {
                var product = _context.Products.FirstOrDefault(p => p.Name == item.Key);
                if (product == null)
                    throw new Exception($"{item.Key} is invalid.");

                if (item.Value > product.AvaiableStock)
                    throw new InsufficientStockException(product.Name);

                order.TotalPrice += product.Price * item.Value;
                product.AvaiableStock -= item.Value;

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    OrderId = order.Id,
                    Quantity = item.Value
                };

                orderItemList.Add(orderItem);
            }

            _context.OrderItems.AddRange(orderItemList);

            _context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
        
    }
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