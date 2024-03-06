using HPCTech2024SpringOrderSystem.Data;
using HPCTech2024SpringOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPCTech2024SpringOrderSystem;

public class OrderSystem
{
    public StoreContext _context { get; set; } = new StoreContext();

    public OrderSystem(StoreContext context)
    {
        _context = context;
    }

    public void AddCustomer(Customer newCustomer)
    {
        _context.Customers.Add(newCustomer);
        _context.SaveChanges();
    }

    public Customer? GetCustomer(Customer newCustomer)
    {
        return (from c in _context.Customers
                where c.FirstName == newCustomer.FirstName && c.LastName == newCustomer.LastName
                select c).FirstOrDefault();
    }

    public List<Order> GetOrders(Customer customer)
    {
        return (    from o in _context.Orders
                    where o.CustomerId == customer.Id
                    select o).ToList();
    }

    public static string MainMenu()
    {
        return $"""
            (L)ist Order
            (P)lace Order
            (Q)uit
            """;
    }

    public string OrderOrderDetailOutput(List<Order> orders)
    {
        string retOrderList = string.Empty;
        foreach (var order in orders)
        {
            retOrderList += order.ToString();
            //List<OrderDetail> details = _context.OrderDetails.Where(od => od.OrderId == order.Id).ToList();
            List<OrderDetail> details = (from od in _context.OrderDetails
                                         where od.OrderId == order.Id
                                         select od).ToList();
            foreach (var detail in details)
            {
                Product product = _context.Products.Find(detail.ProductId)!;
                retOrderList += $"""
                    Product:    {product.Name}
                    Qty:        {detail.Quantity}
                    Price:      {product.Price}
                    """;
            }
        }
        return retOrderList;
    }

    public string OrderMenu()
    {
        string retOrderMenu = string.Empty;
        //List<Product> products = _context.Products.ToList();
        List<Product> products = (  from p in _context.Products
                                    select p).ToList();
        retOrderMenu += "Select a product to order by number:\n";
        foreach (var product in products)
        {
            retOrderMenu += $"""
                ({product.Id}) {product.Name} {product.Price}
                """;
        }
        retOrderMenu += "(Q)uit";
        return retOrderMenu;

    }

    public Product? GetProduct(int id)
    {
        return (from p in _context.Products
                where p.Id == id
                select p).FirstOrDefault();
    }

    public Order AddOrder(Order newOrder)
    {
        _context.Orders.Add(newOrder);
        _context.SaveChanges();
        return newOrder;
    }

    public OrderDetail AddOrderDetail(OrderDetail newOrderDetail)
    {
        _context.OrderDetails.Add(newOrderDetail);
        _context.SaveChanges();
        return newOrderDetail;
    }
}
