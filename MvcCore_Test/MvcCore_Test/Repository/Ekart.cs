using MvcCore_Test.Models;
using MvcCore_Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

public class EkartRepository : IEkartRepositoryInterface
{
    private readonly NorthwindContext _context;

    public EkartRepository(NorthwindContext context)
    {
        _context = context;
    }

    public Order PlaceOrder(Order newOrder)
    {
        _context.Orders.Add(newOrder);
        _context.SaveChanges();
        return newOrder;
    }

    public Order GetOrderDetails(int orderId)
    {
        return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
    }

    private readonly NorthwindContext _context;

    public OrderRepository(NorthwindContext context)
    {
        _context = context;
    }

    public Order PlaceOrder(Order newOrder)
    {
        _context.Orders.Add(newOrder);
        _context.SaveChanges();
        return newOrder;
    }

    public Order GetOrderDetails(int orderId)
    {
        return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
    }

    public Bill DisplayBill(int orderId)
    {
        var order = _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
            return null; // Order not found

        decimal total = 0;
        foreach (var item in order.OrderDetails)
        {
            total += item.UnitPrice * item.Quantity;
        }

        return new Bill
        {
            OrderId = orderId,
            TotalAmount = total
        };
    }

    public List<Customer> GetCustomersByOrderDate(DateTime orderDate)
    {
        return _context.Customers
            .Where(c => c.Orders.Any(o => o.OrderDate.Date == orderDate.Date))
            .ToList();
    }

    public Customer GetCustomerWithHighestOrder()
    {
        var customer = _context.Customers
            .OrderByDescending(c => c.Orders.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)))
            .FirstOrDefault();

        return customer;
    }

    string IEkartRepositoryInterface.DisplayBill(int orderId)
    {
        throw new NotImplementedException();
    }
}
